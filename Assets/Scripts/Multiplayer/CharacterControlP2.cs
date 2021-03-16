using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.UI;
using System;

namespace EasyWiFi.ServerControls
{

    [AddComponentMenu("EasyWiFiController/Server/UserControls/P2Gyro")]
    public class CharacterControlP2 : MonoBehaviour, IServerController
    {

        public string control = "Gyro";
        public EasyWiFiConstants.PLAYER_NUMBER player = EasyWiFiConstants.PLAYER_NUMBER.Player2;

        //speed system
        static public float Speed = 0f;
        float timerDecelleration;
        float timerStop;
        public float jumpForce;

        public Rigidbody2D rb;
        public Text CaloriesText;
        public Text SpeedText;
        public Animator animator;

        public GameObject speedParticle;
        private float speedParticleTimer;

        public GameObject walkingDust;
        public GameObject jumpDust;
        public GameObject dustPoint;

        //Run, Jump and Punch detection
        bool JJUp = false;
        bool Crouching = false;
        bool RunUp = false;
        bool RunDown = false;
        bool RunUp_low = false;
        bool RunDown_low = false;
        private float PunchTimer = 0;
        private float comboTimer = 0;

        //runtime variables
        GyroControllerType[] gyro = new GyroControllerType[EasyWiFiConstants.MAX_CONTROLLERS];
        int currentNumberControllers = 0;
        Quaternion orientation;

        //Text for debugging Rotation
        public Text RotationX;
        public Text RotationY;
        public Text RotationZ;


        void OnEnable()
        {
            EasyWiFiController.On_ConnectionsChanged += checkForNewConnections;

            //do one check at the beginning just in case we're being spawned after startup and after the callbacks
            //have already been called
            if (gyro[0] == null && EasyWiFiController.lastConnectedPlayerNumber >= 0)
            {
                EasyWiFiUtilities.checkForClient(control, (int)player, ref gyro, ref currentNumberControllers);
            }
        }

        void OnDestroy()
        {
            EasyWiFiController.On_ConnectionsChanged -= checkForNewConnections;
        }

        // Update is called once per frame
        void Update()
        {
            //iterate over the current number of connected controllers
            for (int i = 0; i < currentNumberControllers; i++)
            {
                if (gyro[i] != null && gyro[i].serverKey != null && gyro[i].logicalPlayerNumber != EasyWiFiConstants.PLAYERNUMBER_DISCONNECTED)
                {
                    mapDataStructureToAction(i);
                }
            }

            SpeedText.text = "" + Speed.ToString();
            CaloriesText.text = "" +  DataManager.Instance.playerData.stageCalories.ToString("F2");

            if (Speed <= 0.1)
            {
                animator.SetFloat("Speed", 0f);
            }
            if (Speed > 0.1 && Speed <= 3)
            {
                animator.SetFloat("Speed", 0.5f);
            }
            if (Speed > 3 && Speed <= 5)
            {
                animator.SetFloat("Speed", 1f);
            }
            if (Speed > 5 && Speed <= 7)
            {                
                animator.SetFloat("Speed", 1.5f);
            }

            //speed Particle system
            if (Speed >= 5.0f)
            {
                speedParticleTimer -= 1 * Time.deltaTime;
                if(speedParticleTimer < 0f)
                {
                    speedParticle.SetActive(true);
                }
            }
            else if (Speed < 5.5f)
            {
                speedParticle.SetActive(false);
                speedParticleTimer = 2f;
            }

            //Decellarte player and stop after a while
            timerDecelleration += Time.deltaTime * 2f; //set timer for decreasing speed
            timerStop += Time.deltaTime * 1.0f; //set timer for stopping character

            if (Speed >= 0 && timerDecelleration > 1) //Subtract speed each second
            {
                Speed -= Speed * 0.25f;
                timerDecelleration = 0f;

                if (Speed > 0 && Player.isGrounded == true)
                {
                    Instantiate(walkingDust, dustPoint.transform.position, dustPoint.transform.rotation);
                }
            }

            if (timerStop > 0.8 && Speed > 0) //Stop Character if not Walking
            {
                Speed = 0;
                timerStop = 0;
            }

            if (Speed >= 7) //lock minimum speed at 8
            {
                Speed = 7;
            }

            if (PunchTimer > 0) //punching cooldown
            {
                PunchTimer -= 1 * (Time.deltaTime * 2f);
            }

            if (comboTimer > 0) //punching cooldown
            {
                comboTimer -= 1 * (Time.deltaTime * 1f);
            }
            if (comboTimer == 0) //punching cooldown
            {
                Player.combo = 0;
            }
        }

        private void FixedUpdate()
        {
            if (Speed > 0  && Health.invincibilityTimer > 1 && Player.isGrounded) //Move character according to speed
            {
                //rb.velocity = new Vector2(Speed *  DataManager.Instance.playerData.speedSkill, rb.velocity.y) * Time.deltaTime; 
                rb.transform.Translate(Vector2.right * Time.deltaTime * Speed *  DataManager.Instance.playerData.speedSkill, Space.World);
                //rb.AddForce(new Vector2(Time.deltaTime * Speed *  DataManager.Instance.playerData.speedSkill, 0), ForceMode2D.Force);
            }
            //Player hurt animation plays when Invincibility timer is reset:
            if (Health.invincibilityTimer <= 1f)
            {
                animator.SetBool("Hurt", true);
            }
            if (Health.invincibilityTimer > 0.1f)
            {
                animator.SetBool("Hurt", false);
            }

            if(Crouching == true)
            {
                Speed = 0;
            }
        }

        public void mapDataStructureToAction(int index)
        {
            orientation.w = gyro[index].GYRO_W;
            orientation.x = gyro[index].GYRO_X;
            orientation.y = gyro[index].GYRO_Y;
            orientation.z = gyro[index].GYRO_Z;

            transform.localRotation = orientation;


            RotationX.text = "X" + orientation.x.ToString();
            RotationY.text = "Y" + orientation.y.ToString();
            RotationZ.text = "Z" + orientation.z.ToString();

            if (PauseMenu.paused == false)
            {

                //Run arm UP
                if (orientation.x > -0.3 && orientation.z < 0.5 && RunUp == false)
                {
                    RunUp = true;
                }
                //Run arm DOWN
                if (orientation.x < -0.35 && orientation.z < 0.5 && RunDown == false)
                {
                    RunDown = true;

                }
                //Mark one Step + Calories
                if (RunUp == true && RunDown == true && Crouching == false)
                {
                    RunUp = false;
                    RunDown = false;
                     DataManager.Instance.playerData.stepsNumber++;
                    Speed += 0.8f;
                     DataManager.Instance.playerData.stageCalories += 0.04f;
                    timerStop = 0;

                }

                //Run arm UP (for people that move their arms lower)
                if (orientation.x > -0.6 && orientation.z < 0.5 && RunUp_low == false)
                {
                    RunUp_low = true;
                }
                //Run arm DOWN (for people that move their arms lower)
                if (orientation.x < -0.7 && orientation.z < 0.5 && RunDown_low == false)
                {
                    RunDown_low = true;

                }
                //Mark one Step + Calories when moving with arms lower
                if (RunUp_low == true && RunDown_low == true && Crouching == false)
                {
                    RunUp_low = false;
                    RunDown_low = false;
                     DataManager.Instance.playerData.stepsNumber++;
                    Speed += 0.8f;
                     DataManager.Instance.playerData.stageCalories += 0.04f;
                    timerStop = 0;

                }


                if (orientation.x < 0.1 && orientation.y < -0.8 && orientation.z > -0.7 && JJUp == false && Crouching == true && Player.isGrounded == true) //detect getting up from crouch
                {
                    JJUp = false;
                    Crouching = false;
                     DataManager.Instance.playerData.Squats++;
                     DataManager.Instance.playerData.stageCalories += 0.2f;

                    if( DataManager.Instance.playerData.superJump == 0)
                    {
                        Instantiate(jumpDust, new Vector2(dustPoint.transform.position.x, dustPoint.transform.position.y -2), dustPoint.transform.rotation);
                        rb.velocity = new Vector2(0, jumpForce +  DataManager.Instance.playerData.jumpSkill);
                        FindObjectOfType<AudioManager>().Play("hup");
                        Invoke("MoveForward", 0.2f);
                    }

                    animator.SetTrigger("Jump");
                    animator.SetBool("Crouch", false);
                    animator.SetBool("Jumping", true);
                    PunchTimer = 2;

                }

                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z < -0.8 && Crouching == false) //detect Crouch
                {
                    Crouching = true;
                    animator.SetBool("Crouch", true);
                    animator.SetTrigger("Crouch");
                    Speed = 0;
                }



                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z > 0.75 && PunchTimer <= 0) //detect punch
                {
                    if ( DataManager.Instance.playerData.punchCombo == 1 && Player.combo < 3)
                    {
                        comboTimer = 3f;
                        Player.combo += 1;
                    }

                    animator.SetBool("Punch", true);
                    animator.SetTrigger("Attack");
                    Speed = 0;
                    PunchTimer = 1;
                     DataManager.Instance.playerData.stageCalories += 0.04f;
                     DataManager.Instance.playerData.punches++;
                }

                if (orientation.z < 0.4 && PunchTimer <= 0) //detect punch
                {
                    PunchTimer = 0;
                }
            }
        }

        public void MoveForward()
        {
            rb.AddForce(new Vector2(9f +  DataManager.Instance.playerData.jumpSkill/2, 0), ForceMode2D.Impulse);
            //rb.transform.Translate(Vector2.right * 20, Space.World);
        }

        public void checkForNewConnections(bool isConnect, int playerNumber)
        {
            EasyWiFiUtilities.checkForClient(control, (int)player, ref gyro, ref currentNumberControllers);
        }
    }

}

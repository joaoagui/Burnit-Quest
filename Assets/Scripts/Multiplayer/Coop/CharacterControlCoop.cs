using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.UI;
using System;

namespace EasyWiFi.ServerControls
{

    [AddComponentMenu("EasyWiFiController/Server/UserControls/CoopGyro")]
    public class CharacterControlCoop : MonoBehaviour, IServerController
    {

        public string control = "Gyro";
        public EasyWiFiConstants.PLAYER_NUMBER player = EasyWiFiConstants.PLAYER_NUMBER.Player2;

        //speed system
        static public float Speed = 0f;
        private float timerDecelleration;
        private float timerStop;

        private float idleTimer;

        //Hamspoter Action system
        public SpriteRenderer gauge;
        public GameObject hamMedal;
        private float gaugeHeight;
        public static bool charged;

        public Text CaloriesText;
        public Animator animatorHelicopter;
        public Animator animatorHamster;

        public GameObject followTarget;
        public float offsetY;
        public float offsetX;

        public GameObject speedParticle;
        private float speedParticleTimer;

        float P2Calories;

        //Run, Jump and Punch detection
        bool JJUp = false;
        bool Crouching = false;
        bool RunUp = false;
        bool RunDown = false;
        bool RunUp_low = false;
        bool RunDown_low = false;

        private float runTimer = 0.2f;
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

        private void Start()
        {
            gaugeHeight = gauge.size.y;
        }

        // Update is called once per frame
        void Update()
        {
            if (PauseMenu.paused == false)
            {
                //gaugeAnimator.SetFloat("Speed", Speed/4);

                gauge.size += new Vector2(Speed/5f, 0f) * Time.deltaTime;
                runTimer -= Time.deltaTime;


                if (gauge.size.x >= 4)
                {
                    gauge.size = new Vector2(4, gaugeHeight);
                    charged = true;
                    hamMedal.SetActive(true);
                }


                //iterate over the current number of connected controllers
                for (int i = 0; i < currentNumberControllers; i++)
                {
                    if (gyro[i] != null && gyro[i].serverKey != null && gyro[i].logicalPlayerNumber != EasyWiFiConstants.PLAYERNUMBER_DISCONNECTED)
                    {
                        mapDataStructureToAction(i);
                    }
                }


                CaloriesText.text = "" + P2Calories.ToString("F2");

                if (Speed <= 0.1)
                {
                    animatorHamster.SetFloat("Speed", 0f);
                    animatorHelicopter.SetFloat("Speed", 0.25f);

                }
                if (Speed > 0.1 && Speed <= 3)
                {
                    animatorHamster.SetFloat("Speed", 0.5f);
                    animatorHelicopter.SetFloat("Speed", 0.5f);

                }
                if (Speed > 3 && Speed <= 5)
                {
                    animatorHamster.SetFloat("Speed", 1f);
                    animatorHelicopter.SetFloat("Speed", 1f);

                }
                if (Speed > 5 && Speed <= 7)
                {
                    animatorHamster.SetFloat("Speed", 1.5f);
                    animatorHelicopter.SetFloat("Speed", 1.5f);

                }

                //speed Particle system
                if (Speed >= 5.0f)
                {
                    speedParticleTimer -= 1 * Time.deltaTime;
                    if (speedParticleTimer < 0f)
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
                idleTimer += Time.deltaTime * 1.0f;

                if (Speed >= 0 && timerDecelleration > 1) //Subtract speed each second
                {
                    Speed -= Speed * 0.25f;
                    timerDecelleration = 0f;
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

                if (idleTimer < 10)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(followTarget.transform.position.x + offsetX, followTarget.transform.position.y + offsetY), Speed / 50);

                }
                else if (idleTimer >= 10)
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(followTarget.transform.position.x + offsetX, followTarget.transform.position.y + offsetY), 0.1f);
                }
            }
       
        }



        public void mapDataStructureToAction(int index)
        {
            orientation.w = gyro[index].GYRO_W;
            orientation.x = gyro[index].GYRO_X;
            orientation.y = gyro[index].GYRO_Y;
            orientation.z = gyro[index].GYRO_Z;

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
                if (RunUp == true && RunDown == true && Crouching == false && runTimer < 0)
                {
                    runTimer = 0.2f;

                    RunUp = false;
                    RunDown = false;
                    Speed += 0.8f;
                    P2Calories += 0.04f;
                    timerStop = 0;

                    idleTimer = 0;

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
                if (RunUp_low == true && RunDown_low == true && Crouching == false && runTimer < 0)
                {
                    runTimer = 0.2f;

                    RunUp_low = false;
                    RunDown_low = false;
                    Speed += 0.8f;
                    P2Calories += 0.04f;
                    timerStop = 0;
                    idleTimer = 0;

                    idleTimer = 0;

                }


                if (orientation.x < 0.1 && orientation.y < -0.8 && orientation.z > -0.7 && JJUp == false && Crouching == true) //detect getting up from crouch
                {
                    JJUp = false;
                    Crouching = false;
                    P2Calories += 0.2f;
                    PunchTimer = 2;
                    animatorHamster.SetBool("Crouch", false);

                    idleTimer = 0;

                    gauge.size = new Vector2(0, gaugeHeight);
                    charged = false;
                    hamMedal.SetActive(false);


                }

                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z < -0.8 && Crouching == false && charged == true) //detect Crouch
                {
                    Crouching = true;
                    animatorHamster.SetBool("Crouch", true);
                    Speed = 0;

                    idleTimer = 0;

                }

                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z > 0.75 && PunchTimer <= 0 && charged == true) //detect punch
                {
                    charged = false;

                    animatorHamster.SetBool("Punch", true);
                    Speed = 0;
                    PunchTimer = 1;
                    P2Calories += 0.04f;

                    idleTimer = 0;

                    gauge.size = new Vector2(0, gaugeHeight);
                    hamMedal.SetActive(false);

                }

                if (orientation.z < 0.4 && PunchTimer <= 0) //detect punch
                {
                    animatorHamster.SetBool("Punch", false);

                    PunchTimer = 0;
                }
            }
        }        

        public void checkForNewConnections(bool isConnect, int playerNumber)
        {
            EasyWiFiUtilities.checkForClient(control, (int)player, ref gyro, ref currentNumberControllers);
        }
    }

}

using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.UI;
using System;

namespace EasyWiFi.ServerControls
{

    [AddComponentMenu("EasyWiFiController/Server/UserControls/CoopUnderwaterGyro")]
    public class CoopUnderwaterGyro : MonoBehaviour, IServerController
    {

        public Rigidbody2D rb;
        public float swimSpeed;

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
        public Animator animator;


        public GameObject followTarget;
        public float offsetY;
        public float offsetX;

        public Transform firePoint;
        public GameObject bullet;

        float P2Calories;

        //Run, Jump and Punch detection
        bool JJUp = false;
        bool Crouching = false;
        bool JJDown = false;


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
            gauge.size += new Vector2(Speed / 5f, 0f) * Time.deltaTime;

            if (gauge.size.x >= 4)
            {
                gauge.size = new Vector2(4, gaugeHeight);
                charged = true;
                hamMedal.SetActive(true);
            }


            if (PauseMenu.paused == false)
            {
                //gaugeAnimator.SetFloat("Speed", Speed/4);

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

                idleTimer += Time.deltaTime * 1.0f;

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


                if(transform.position.y > (followTarget.transform.position.y + (offsetY * 2)))
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(followTarget.transform.position.x + offsetX, followTarget.transform.position.y + offsetY), 0.05f);
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

                //Detect arms up when doing Jumping Jacks
                if (orientation.z < -0f && orientation.y < -0.65f && JJUp == false)
                {
                    JJDown = false;
                    JJUp = true;
                    animator.SetBool("Swim", true);
                }
                //Detect arms down when doing Jumping Jacks
                if (orientation.z < -0f && orientation.y > 0.65f && JJDown == false)
                {
                    JJDown = true;
                }

                //Mark one one Jumping Jack and Calories
                if (JJUp == true && JJDown == true)
                {
                    JJUp = false;
                    JJDown = false;
                    P2Calories += 0.04f;
                    timerStop = 0;

                    rb.AddForce(new Vector2(0, swimSpeed), ForceMode2D.Impulse);
                    gauge.size += new Vector2(1f, 0f);

                    animator.SetBool("Swim", false);

                }

                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z > 0.75 && charged == true) //detect punch
                {

                    //Reset Gauge
                    charged = false;
                    idleTimer = 0;
                    gauge.size = new Vector2(0, gaugeHeight);
                    hamMedal.SetActive(false);

                    GameObject newBullet = Instantiate(bullet, firePoint.position, new Quaternion(0,0,0,0));
                    newBullet.transform.Rotate(0, 0, 90);

                    P2Calories += 0.04f;
                }

                if (orientation.z < 0.4 && PunchTimer <= 0) //detect punch
                {
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

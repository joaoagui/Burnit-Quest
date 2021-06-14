using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.UI;
using System;

namespace EasyWiFi.ServerControls
{

    [AddComponentMenu("EasyWiFiController/Server/UserControls/Underwater Control")]
    public class UnderwaterControl : MonoBehaviour, IServerController
    {

        public string control = "Gyro";
        public EasyWiFiConstants.PLAYER_NUMBER player = EasyWiFiConstants.PLAYER_NUMBER.Player1;

        //speed system
        float timerDecelleration;
        float timerStop;
        public float swimSpeed;
        private float startPositionX;

        public GameObject playerObject;
        public Rigidbody2D rb;
        public Text CaloriesText;
        public Text SpeedText;
        public Animator animator;

        public GameObject dustPoint;

        //Run, Jump and Punch detection
        bool JJUp = false;
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
            startPositionX = playerObject.transform.position.x;
        }

        // Update is called once per frame
        void Update()
        {
            if(playerObject.transform.position.x > startPositionX || playerObject.transform.position.x < startPositionX)
            {
                playerObject.transform.position = Vector2.MoveTowards(playerObject.transform.position, new Vector2(startPositionX, playerObject.transform.position.y), 0.04f);
            }
            //iterate over the current number of connected controllers
            for (int i = 0; i < currentNumberControllers; i++)
            {
                if (gyro[i] != null && gyro[i].serverKey != null && gyro[i].logicalPlayerNumber != EasyWiFiConstants.PLAYERNUMBER_DISCONNECTED)
                {
                    mapDataStructureToAction(i);
                }
            }

            CaloriesText.text = "" +  DataManager.Instance.playerData.stageCalories.ToString("F2");

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
            if (Health.invincibilityTimer <= 1f)
            {
                animator.SetBool("Hurt", true);
            }
            if (Health.invincibilityTimer > 0.1f)
            {
                animator.SetBool("Hurt", false);
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
                    DataManager.Instance.playerData.jumpingJacks ++;
                    DataManager.Instance.playerData.stageCalories += 0.04f;
                    timerStop = 0;
                    animator.SetTrigger("Swim");
                }
                
                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z > 0.75 && PunchTimer <= 0) //detect punch
                {
                    if ( DataManager.Instance.playerData.punchCombo == 1 && Player.combo < 3)
                    {
                        comboTimer = 3f;
                        Player.combo += 1;
                    }

                    animator.SetBool("Punch", true);
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


        public void checkForNewConnections(bool isConnect, int playerNumber)
        {
            EasyWiFiUtilities.checkForClient(control, (int)player, ref gyro, ref currentNumberControllers);
        }
    }

}

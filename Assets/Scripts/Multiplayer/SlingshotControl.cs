using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.UI;
using System;

namespace EasyWiFi.ServerControls
{

    [AddComponentMenu("EasyWiFiController/Server/UserControls/Slingshot Control")]
    public class SlingshotControl : MonoBehaviour, IServerController
    {

        public string control = "Gyro";
        public EasyWiFiConstants.PLAYER_NUMBER player = EasyWiFiConstants.PLAYER_NUMBER.Player1;

        public Text CaloriesText;
        public Animator animator;

        public GameObject Shot;
        public Transform firePoint;
        private float punchTimer;

        //runtime variables
        GyroControllerType[] gyro = new GyroControllerType[EasyWiFiConstants.MAX_CONTROLLERS];
        int currentNumberControllers = 0;
        Quaternion orientation;

        //Text for debugging Rotation
        public Text RotationX;
        public Text RotationY;
        public Text RotationZ;

        bool pull = false;

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

            CaloriesText.text = "" +  DataManager.Instance.playerData.stageCalories.ToString("F2");


            if (punchTimer > 0) //punching cooldown
            {
                punchTimer -= 1 * (Time.deltaTime * 2f);
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

                if (orientation.x < 0.1 && orientation.y < 0.1 && orientation.z > 0.55 && punchTimer <= 0 && pull == false) 
                {
                    animator.SetBool("Pull", true);
                    pull = true;
                    DataManager.Instance.playerData.stageCalories += 0.2f;
                }

                if (orientation.z < 0.2 && punchTimer <= 0 && pull == true) 
                {
                    animator.SetBool("Pull", false);
                    pull = false;
                }
            }
        }

        public void checkForNewConnections(bool isConnect, int playerNumber)
        {
            EasyWiFiUtilities.checkForClient(control, (int)player, ref gyro, ref currentNumberControllers);
        }
    }

}

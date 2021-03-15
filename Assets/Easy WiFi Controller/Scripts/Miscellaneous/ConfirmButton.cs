using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.SceneManagement;

[AddComponentMenu("EasyWiFiController/Miscellaneous/ConfirmButton")]
public class ConfirmButton : MonoBehaviour {

    bool isPressed;
  
    void ButtonPress(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;

        if (isPressed)
        {
            SceneManager.LoadScene("Stage1");
        }

    }
}

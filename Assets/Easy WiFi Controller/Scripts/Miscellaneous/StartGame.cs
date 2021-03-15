using UnityEngine;
using System.Collections;
using EasyWiFi.Core;
using UnityEngine.SceneManagement;

[AddComponentMenu("EasyWiFiController/Miscellaneous/StartGame")]
public class StartGame : MonoBehaviour {

    MeshRenderer myRenderer;
    Material myMaterial;
    Color originalColor;
    bool isPressed;
    public AudioSource start;


    void Start() 
    {
        myRenderer = this.GetComponent<MeshRenderer>();
        myMaterial = myRenderer.material;
        originalColor = myMaterial.color;
    }

    void changeColor(ButtonControllerType button)
    {
        isPressed = button.BUTTON_STATE_IS_PRESSED;

        if (isPressed == true)
        {
            Debug.Log("LoardingScene");
            SceneManager.LoadScene("StageSelect");
            start.Play();
        }
        else
            myMaterial.color = originalColor;

    }
}

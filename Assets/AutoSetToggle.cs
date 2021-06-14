using UnityEngine;
using UnityEngine.UI;

public class AutoSetToggle : MonoBehaviour
{
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle.GetComponent<Toggle>();

        if(CoopManager.CoopEnabled == true)
        {
            toggle.isOn = true;
        }

        else if (CoopManager.CoopEnabled == false)
        {
            toggle.isOn = false;
        }
    }
}

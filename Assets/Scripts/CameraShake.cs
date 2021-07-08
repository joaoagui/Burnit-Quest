using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    public UnityEvent shake;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shake", 3f, 4f);
    }


    private void Shake()
    {
        shake.Invoke();
    }
}

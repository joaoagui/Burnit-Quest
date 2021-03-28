using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool clockwise;

    public float rotationSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if(clockwise == true)
        {
            gameObject.transform.Rotate(0, 0, -rotationSpeed, Space.Self);
        }

        else if (clockwise == false)
        {
            gameObject.transform.Rotate(0, 0, rotationSpeed, Space.Self);
        }
    }
}

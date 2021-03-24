using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Shot;

    public void Fire()
    {
        Instantiate(Shot, firePoint.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPosition : MonoBehaviour
{
    public Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void lockPosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}

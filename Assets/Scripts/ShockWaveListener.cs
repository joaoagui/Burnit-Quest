using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShockWaveListener : MonoBehaviour
{
    private CinemachineImpulseSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("Shake", 3f, 4f);
    }

    public void Shake()
    {
        source.GenerateImpulse();
    }
}

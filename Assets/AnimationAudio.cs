using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudio : MonoBehaviour
{
    private  AudioSource audioSource;
    public AudioClip clip;

    [Range(0.0f, 1.0f)]
    public float volume = 1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip()
    {
        audioSource.PlayOneShot(clip, volume);

    }
}

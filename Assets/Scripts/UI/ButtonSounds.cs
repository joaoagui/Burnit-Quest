using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource select;

    public void OnPointerEnter(PointerEventData ped)
    {
        select.Play();
    }

    public void OnSelect(BaseEventData eventData)
    {
        select.Play();
    }
}


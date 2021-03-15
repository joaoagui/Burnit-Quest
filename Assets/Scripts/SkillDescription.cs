using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SkillDescription : MonoBehaviour, ISelectHandler
{
    public TextMeshPro titleTxt;
    public TextMeshPro descriptionTxt;
    public string title;
    public string description;

    private void Update()
    {
    }


    public void OnSelect(BaseEventData eventData)
    {
        descriptionTxt.text = "" + description;
        titleTxt.text = "" + title;
        Debug.Log("btn selected");
    }

}
using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine;
using UnityEngine.UI;
using EasyWiFi.Core;

namespace EasyWiFi.ClientControls
{
    // Button that's meant to work with mouse or touch-based devices.
    [AddComponentMenu("EasyWiFiController/Client/UserControls/ScrollableButton")]
    public class ScrollableButtonClientController : Selectable, IPointerDownHandler, IPointerUpHandler //IPointerClickHandler, ISubmitHandler
    {
        public string controlName = "ScrollableButton1";

        ButtonControllerType button;
        string buttonKey;
        bool pressed;



        protected ScrollableButtonClientController()
        { }

        protected override void Awake()
        {
            base.Awake();
            if (Application.isPlaying)
            {
                buttonKey = EasyWiFiController.registerControl(EasyWiFiConstants.CONTROLLERTYPE_BUTTON, controlName);
                button = (ButtonControllerType)EasyWiFiController.controllerDataDictionary[buttonKey];
            }
        }


        public void Update()
        {
            if (!IsActive() || !IsInteractable() || button == null)
                return;

            if (pressed)
            {
                button.BUTTON_STATE_IS_PRESSED = true;
            }
            else
            {
                button.BUTTON_STATE_IS_PRESSED = false;

            }

        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            pressed = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            pressed = false;
        }
        /*
                // Trigger all registered callbacks.
                public virtual void OnPointerClick(PointerEventData eventData)
                {
                    if (eventData.button != PointerEventData.InputButton.Left)
                        return;

                    Press();
                }

                public virtual void OnSubmit(BaseEventData eventData)
                {
                    Press();

                    // if we get set disabled during the press
                    // don't run the coroutine.
                    if (!IsActive() || !IsInteractable())
                        return;

                    DoStateTransition(SelectionState.Pressed, false);
                    StartCoroutine(OnFinishSubmit());
                }

                private IEnumerator OnFinishSubmit()
                {
                    var fadeTime = colors.fadeDuration;
                    var elapsedTime = 0f;

                    while (elapsedTime < fadeTime)
                    {
                        elapsedTime += Time.unscaledDeltaTime;
                        yield return null;
                    }

                    DoStateTransition(currentSelectionState, false);
                } */
    }
}
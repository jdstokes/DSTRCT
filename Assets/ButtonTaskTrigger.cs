using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonTaskTrigger : TaskTrigger
{
    public Button startButton;
    public Canvas canvas;
    private Action backTrigger;

    public override void ActivateTrigger(Action trigger)
    {
        backTrigger = trigger;
        ActivateStartButton();
    }

    public void ActivateStartButton()
    {
        canvas.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);

       startButton.onClick.AddListener(StartButtonClick);
    }

    public void DeactivateStartButton()
    {
        canvas.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        startButton.onClick.RemoveListener(StartButtonClick);
    }

    public void StartButtonClick()
    {
        DeactivateStartButton();
        backTrigger();
    }
}

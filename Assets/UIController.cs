using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : Singleton<UIController>
{
    public Button startButton;
    public Canvas canvas;
    public Action OnStartButtonClick; 

    public void ActivateStartButton()
    {
        canvas.gameObject.SetActive(true);
        startButton.onClick.AddListener(StartButtonClick);
    }

    public void DeactivateStartButton()
    {
        canvas.gameObject.SetActive(false);
        startButton.onClick.RemoveListener(StartButtonClick);
    }

    public void StartButtonClick()
    {
        if (OnStartButtonClick != null)
        {
            OnStartButtonClick();
        }
    }
}

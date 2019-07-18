using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskEventOnButton : TaskEvent
{
    public Button button;
    public Canvas canvas;
    bool taskOn;

    public override  IEnumerator StartEventsAsync()
    {
        taskOn = true;
        ActivateStartButton();
        while (taskOn)
        {
            yield return null;
        }
    }

    public void ActivateStartButton()
    {
        canvas.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        button.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        canvas.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        taskOn = false;
        button.onClick.RemoveListener(ButtonClicked);
    }
}

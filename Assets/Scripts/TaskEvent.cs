using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TaskEvent : MonoBehaviour
{
   public UnityEvent eventStarted;
   public TaskTrigger endTriggerController;
   public Action onEndTrigger;

    public void StartEvent(Action nextEvent)
    {
        onEndTrigger = nextEvent;
        eventStarted.Invoke();
        ActivateEndTrigger();
    }

    void ActivateEndTrigger()
    {
        endTriggerController.ActivateTrigger(onEndTrigger);
    }


}

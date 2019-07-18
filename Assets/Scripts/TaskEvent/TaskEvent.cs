using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TaskEvent : MonoBehaviour
{
   public UnityEvent eventStarted;
   public GameObject eventController;
    public float waitTime;

    public void Activate()
    {
        Debug.Log("Activate: " + this.name);
        eventStarted.Invoke();
        StartCoroutine(StartEvent());
    }

    public IEnumerator StartEvent()
    {
        yield return StartCoroutine(StartEventsAsync());
        yield return new WaitForSeconds(waitTime);
        eventController.SendMessage("OnEventEnd");
    }

    public virtual IEnumerator StartEventsAsync()
    {
        yield return null;
    }

}

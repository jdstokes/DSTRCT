using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trial : MonoBehaviour
{
    public List<TaskEvent> trialEvents = new List<TaskEvent>();
    public Action eventEnd;
    public Action trialEnd;
    private int eventCnt;

    private void OnEnable()
    {
        eventEnd += NextEvent;
    }

    private void OnDisable()
    {
        eventEnd -= NextEvent;
    }


    public void StartTrial(Action trialEnd)
    {
        this.trialEnd = trialEnd;
        RunTrial();
    }

    public void RunTrial()
    {
        Debug.Log("Trial started");
        eventCnt = 0;
        RunEvent();
    }

    private void RunEvent()
    {
        trialEvents[eventCnt].StartEvent(eventEnd);
    }


    private void NextEvent()
    {
        eventCnt++;
        if(eventCnt < trialEvents.Count)
        {
            Debug.Log("Next event");
            Debug.Log(trialEvents[eventCnt].gameObject.name);

            RunEvent();
        }
        else
        {
            trialEnd();
        }
    }
}

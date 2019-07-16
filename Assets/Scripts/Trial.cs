using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trial : MonoBehaviour
{
    public List<TaskEvent> trialEvents = new List<TaskEvent>();
    public Action eventEnd;
    public Action endTrials;
    private int eventCnt;
    private int trialCnt;
    private int numberOftrials;

    private void OnEnable()
    {
        eventEnd += NextEvent;
    }

    private void OnDisable()
    {
        eventEnd -= NextEvent;
    }


    public void StartTrials(Action end, int numTrials)
    {
        endTrials = end;
        numberOftrials = numTrials;
        trialCnt = 0;
        RunTrial();
    }

    public void RunTrial()
    {
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
        else if(trialCnt < numberOftrials)
        {
                trialCnt++;
                RunTrial();
        }
        else {
            endTrials();
        }
    }
}

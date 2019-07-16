using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    int numberOfTrials = 3;
    int cnt;
    public List<TaskEvent> blockEvents = new List<TaskEvent>();
    public Action eventEnd;
    public Action onTrialsEnd;
    public Trial trials;

    private void OnEnable()
    {
        eventEnd += NextEvent;
    }

    private void OnDisable()
    {
        eventEnd -= NextEvent;
    }


    public void StartBlock()
    {
        cnt = 0;
        RunEvent();
    }

    private void RunEvent()
    {
        blockEvents[cnt].StartEvent(eventEnd);
    }


    private void NextEvent()
    {
        cnt++;
        if (cnt < blockEvents.Count)
        {
            Debug.Log("Next event");

            RunEvent();
        }
        else
        {
            Debug.Log("End");
        }
    }

    public void RunBlockTrials()
    {
        Debug.Log("Start trials");
        trials.StartTrials(onTrialsEnd, numberOfTrials);
    }

}

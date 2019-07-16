using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    int cnt;
    public List<TaskEvent> blockEvents = new List<TaskEvent>();
    public Action eventEnd;
    public Action blockEnd;

    private void OnEnable()
    {
        eventEnd += NextEvent;
    }

    private void OnDisable()
    {
        eventEnd -= NextEvent;
    }


    public void StartBlock(Action blockEnd)
    {
        Debug.Log("Block started");
        this.blockEnd = blockEnd;
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
            blockEnd();
        }
    }

}

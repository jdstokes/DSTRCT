using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskEventLoop : TaskEvent
{

    public TaskEvent taskEvent;
    public int numEvents;
    private bool eventOn;
    private int cnt;

    public override IEnumerator StartEventsAsync()
    {
        cnt = 0;
        eventOn = true;
        NewEvent();
        while(cnt < numEvents)
        {
            yield return null;
        }      
    }

    void NewEvent()
    {
        Debug.Log("Next trial");
        taskEvent.Activate();
    }

    void OnEventEnd()
    {
        cnt++;
 
        if (cnt < numEvents)
        {
            NewEvent();
        }
        else
        {
            eventOn = false;
        }
    }
}

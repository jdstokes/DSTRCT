using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TaskEventSubmodules : TaskEvent
{
    int cnt;
    public List<TaskEvent> eventList = new List<TaskEvent>();
    bool eventOn;

    public override IEnumerator StartEventsAsync()
    {
        cnt = 0;
        eventOn = true;
        NewEvent();
        while (eventOn)
        {
            yield return null;
        }
    }

    void OnEventEnd()
    {
        cnt++;
        if(cnt < eventList.Count)
        {
            NewEvent();
        }
        else
        {
            eventOn = false;
        }
    }

    private void NewEvent()
    {
        Debug.Log(this.name + ", NEW EVENT, " + cnt.ToString());
        eventList[cnt].Activate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskEventOnTargetFound : TaskEvent
{
    bool eventOn;
    public float targetWaitTime;

    public override IEnumerator StartEventsAsync()
    {
        InputController.Instance.OnTargetFound += EndEvent;
        eventOn = true;
        StartCoroutine(TargetWait());
        while (eventOn)
        {
            yield return null;
        }
    }

    private IEnumerator TargetWait()
    {
        yield return new WaitForSeconds(targetWaitTime);
        EndEvent();
    }

    private void EndEvent()
    {
        Debug.Log("Target found end event");
        InputController.Instance.OnTargetFound -= EndEvent;
        eventOn = false;
    }
}

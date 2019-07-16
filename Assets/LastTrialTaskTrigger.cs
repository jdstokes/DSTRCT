using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LastTrialTaskTrigger : TaskTrigger
{
    public Trial trials;
    private bool trialsOn;

    private void OnEnable()
    {
        trials.endTrials += TrialsEnded;
    }

    private void OnDisable()
    {
        trials.endTrials -= TrialsEnded;

    }

    public override void ActivateTrigger(Action trigger)
    {
        trialsOn = true;
        StartCoroutine(WaitTrialBlock(trigger));
    }

    IEnumerator WaitTrialBlock(Action trigger)
    {
        while (trialsOn)
        {
            yield return null;
        }
        trigger();
    }

    private void TrialsEnded()
    {
        trialsOn = false;
    }
}

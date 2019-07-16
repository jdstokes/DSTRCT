using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LastTrialTaskTrigger : TaskTrigger
{

    private bool trialsOn;
    public TrialList trialList;

    public override void ActivateTrigger(Action trigger)
    {

        trialList.StartTrialList(trigger);
    }


}

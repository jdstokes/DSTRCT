using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CountDownTaskTrigger : TaskTrigger
{
    public float countDownTime;

    public override void ActivateTrigger(Action trigger)
    {
        StartCoroutine(Waittime(trigger));
    }

    IEnumerator Waittime(Action trigger)
    {
        yield return new WaitForSeconds(countDownTime);
        trigger();
        Debug.Log("count down trigger called");
    }
}

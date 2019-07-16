using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class TaskTrigger : MonoBehaviour
{
    public virtual void ActivateTrigger(Action trigger)
    {
        //StartCoroutine(Waittime(trigger));
    }

    //IEnumerator Waittime(Action trigger)
    //{
    //    yield return new WaitForSeconds(1f);
    //    trigger();
    //}
}

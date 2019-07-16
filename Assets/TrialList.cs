using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrialList : MonoBehaviour
{

    public Trial trial;
    private int numTrials = 2;
    private int cnt = 0;
    Action OnEndTrialTrigger;
    Action OnEndTrialLoopTrigger;

    private void OnEnable()
    {
        OnEndTrialTrigger += EndTrial;
    }

    private void OnDisable()
    {
        OnEndTrialTrigger -= EndTrial;
    }


    public void StartTrialList(Action onEnd)
    {
        OnEndTrialLoopTrigger = onEnd;
        cnt = 0;
        NextTrial();
    }

    void NextTrial()
    {
        Debug.Log("Next trial");
        trial.StartTrial(OnEndTrialTrigger);
    }

    void EndTrial()
    {
        Debug.Log("Trial over");
        cnt++;
        if(cnt < numTrials)
        {
            NextTrial();
        }
        else
        {
            Debug.Log("Trial list over");
            if (OnEndTrialLoopTrigger!=null)
            {
                OnEndTrialLoopTrigger();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TriggerType { startBlock, startTrial, endTrial };

public class ExperimentController : Singleton<ExperimentController>
{

  
    public event Action OnTrialSetup;
    public event Action OnTrialPre;
    public event Action OnTrialStart;
    public event Action OnTrialEnd;

    public event Action OnBlockSetup;
    public event Action OnBlockPre;
    public event Action OnBlockStart;
    public event Action OnBlockEnd;

    public event Action OnStartExperiment;

    private bool _endTrialTriggerOn;
    private bool _startTrialTriggerOn;
    private bool _startBlockTriggerOn;

    // use if we need to wait for method to complete
    public delegate IEnumerator WaitTrialSetup();
    public delegate IEnumerator WaitTrialPre();


    public event Action startBlockTrigger;
    public event Action startTrialTrigger;
    public event Action endTrialTrigger;


    public int numberOfTrials;
    public int numberOfBlocks;


    public void Trigger(TriggerType triggerType)
    {
        switch (triggerType)
        {
            case TriggerType.startBlock:
                startBlockTrigger();
                break;
            case TriggerType.startTrial:
                startTrialTrigger();
                break;
            case TriggerType.endTrial:
                endTrialTrigger();
                break;
        }

    }

    // Start experiment
    public void Run()
    {
        StartCoroutine(RunExperiment());
    }

    /// <summary>
    /// </summary>
    private IEnumerator RunExperiment()
    {
        yield return StartCoroutine(StartExperiment());
        yield return StartCoroutine(Blocks());
        Debug.Log("Experiment finished");
    }

    IEnumerator StartExperiment()
    {
        if (OnStartExperiment != null)

        {
            Debug.Log("Experiment started");
            OnStartExperiment();
        }
        yield return null;
    }

    IEnumerator Blocks()
    {
        for (int i = 0; i < numberOfBlocks; i++)
        {
            Debug.Log("Block " + i.ToString());
            yield return StartCoroutine(SetUpBlock());
            yield return StartCoroutine(PreBlock());
            yield return StartCoroutine(StartBlock());
            yield return StartCoroutine(EndBlock());
        }
    }
    IEnumerator Trials()
    {
        for (int i = 0; i < numberOfTrials; i++)
        {
            Debug.Log("Trial " + i.ToString());
            yield return StartCoroutine(SetUpTrial());
            yield return StartCoroutine(PreTrial());
            yield return StartCoroutine(StartTrial());
            yield return StartCoroutine(EndTrial());
        }
    }

    // Block start trigger
    IEnumerator AwakeBlockStartTrigger()
    {
        startBlockTrigger += StopStartBlockTrigger;
        yield return StartCoroutine(WaitForBlockStartTrigger());
        startBlockTrigger -= StopStartBlockTrigger;
    }

    IEnumerator WaitForBlockStartTrigger()
    {
        _startBlockTriggerOn = true;
        while (_startBlockTriggerOn)
        {
            yield return null;
        }
        _startBlockTriggerOn = true;
    }

    void StopStartBlockTrigger()
    {
        Debug.Log("Stop block start trigger");
        _startBlockTriggerOn = false;
    }


    // Trial start trigger
    IEnumerator AwakeTrialStartTrigger()
    {
        startTrialTrigger += StopStartTrialTrigger;
        yield return StartCoroutine(WaitForTrialStartTrigger());
        startTrialTrigger -= StopStartTrialTrigger;
    }

    IEnumerator WaitForTrialStartTrigger()
    {
        _startTrialTriggerOn = true;
        while (_startTrialTriggerOn)
        {
            yield return null;
        }
        _startTrialTriggerOn = true;
    }

    void StopStartTrialTrigger()
    {
        Debug.Log("Stop trial start trigger");
        _startTrialTriggerOn = false;
    }

    // Trial end trigger
    IEnumerator AwakeTrialEndTrigger()
    {
        endTrialTrigger += StopEndTrialTrigger;
        yield return StartCoroutine(WaitForTrialEndTrigger());
        endTrialTrigger -= StopEndTrialTrigger;
    }

    IEnumerator WaitForTrialEndTrigger()
    {
        _endTrialTriggerOn = true;
        while (_endTrialTriggerOn)
        {
            yield return null;
        }
        _endTrialTriggerOn = true;
    }

    void StopEndTrialTrigger()
    {
        Debug.Log("Stop trial end trigger");
        _endTrialTriggerOn = false;
    }


   
    IEnumerator SetUpTrial()
    {
        Debug.Log("Trial set up");

        if (OnTrialSetup != null)
        {
            OnTrialSetup();
        }
        yield return null;
    }

    IEnumerator PreTrial()
    {
        Debug.Log("Trial pre");

        if (OnTrialPre != null)
        {
            OnTrialPre();
        }
        yield return StartCoroutine(AwakeTrialStartTrigger());
    }

    IEnumerator StartTrial()
    {
        Debug.Log("Trial started");

        if (OnTrialStart != null)
        {
            OnTrialStart();
        }
        
        yield return StartCoroutine(AwakeTrialEndTrigger());
    }

    IEnumerator EndTrial()
    {
        Debug.Log("Trial ended");

        if (OnTrialEnd != null)
        {
            OnTrialEnd();
        }
        yield return null;
    }

    IEnumerator SetUpBlock()
    {
        Debug.Log("Block set up");

        if (OnBlockSetup != null)
        {
            OnBlockSetup();
        }
        yield return null;
    }

    IEnumerator PreBlock()
    {
        Debug.Log("Block pre");

        if (OnBlockPre != null)
        {
            OnBlockPre();
        }
        yield return StartCoroutine(AwakeBlockStartTrigger());
    }

    IEnumerator StartBlock()
    {
        Debug.Log("Block started");

        if (OnBlockStart != null)
        {
            OnBlockStart();
        }
        yield return StartCoroutine(Trials());
    }

    IEnumerator EndBlock()
    {
        Debug.Log("Block ended");

        if (OnBlockEnd != null)
        {
            OnBlockEnd();
        }
        yield return null;
    }

}

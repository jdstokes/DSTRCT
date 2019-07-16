using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainTest : MonoBehaviour
{
    public float trialTime = 1f;
    public float itiTime = 1f;

    public event Action OnStartExperiment;

    private void OnEnable()
    {
        ExperimentController.Instance.OnBlockPre += WaitForStartBlockTrigger;
        // ExperimentController.Instance.OnTrialPre += WaitForStartTrialTrigger;
        ExperimentController.Instance.OnTrialPre += TrialPre;
        ExperimentController.Instance.OnTrialPre += TrialStart;
        ExperimentController.Instance.OnTrialStart += WaitForEndTrialTrigger;
    }

    private void OnDisable()
    {
        ExperimentController.Instance.OnBlockPre -= WaitForStartBlockTrigger;

        ExperimentController.Instance.OnTrialPre -= TrialPre;
        ExperimentController.Instance.OnTrialPre -= TrialStart;

        // ExperimentController.Instance.OnTrialPre -= WaitForStartTrialTrigger;
        ExperimentController.Instance.OnTrialStart -= WaitForEndTrialTrigger;
    }

    private void TrialPre()
    {
        UIController.Instance.ActivateStartButton();
    }

    private void TrialStart()
    {

    }

    private void TrialEnd()
    {

    }

    private void BlockSetup()
    {

    }

    public void WaitForStartBlockTrigger()
    {
        StartCoroutine(StartTriggerCountDown(TriggerType.startBlock,0f));
    }

    public void WaitForStartTrialTrigger()
    {
        StartCoroutine(StartTriggerCountDown(TriggerType.startTrial,0f));
    }

    public void WaitForEndTrialTrigger()
    {
        StartCoroutine(StartTriggerCountDown(TriggerType.endTrial,trialTime));
    }

    IEnumerator StartTriggerCountDown(TriggerType type, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ExperimentController.Instance.Trigger(type);
    }

    /// <summary>
    /// Start trial trigger
    /// </summary>
    public void StartTrialTrigger()
    {
        ExperimentController.Instance.Trigger(TriggerType.startTrial);
    }


    private void Start()
    {
        ExperimentController.Instance.Run();
    }


}

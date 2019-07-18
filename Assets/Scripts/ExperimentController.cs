using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentController : MonoBehaviour
{
    public TaskEvent Experiment;

    [Header("Experiment Settings")]
    public int numberOfTrials = 3;
    public int numberOfDistractors = 1;
    public float trialTime = 1f;
    public float itiTime = 1f;
    public int numberOfBlocks = 1;

    [Header("Experiment Data")]
    public int trialCount;
    public int blockCount;

    [Header("Object Settings")]
    public GameObject distractor;

    [Header("UI")]
    public Button endTaskButton;
    public Canvas canvas;


    private void Start()
    {
        Experiment.Activate();
    }

    private void OnEventEnd()
    {
        Debug.Log("Experiment over");
        canvas.gameObject.SetActive(true);
        endTaskButton.gameObject.SetActive(true);
        endTaskButton.onClick.AddListener(QuitRequest);
    }

    public void QuitRequest()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		            Application.Quit();
#endif
    }



    public void SpawnTarget()
    {
        Debug.Log("Spawn target");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Experiment : MonoBehaviour
{
    public Block block;
    Action OnEndBlockTrigger;
    Action OnEndBlockLoopTrigger;

    private void OnEnable()
    {
        OnEndBlockTrigger += BlockEnded;
    }

    private void OnDisable()
    {
        OnEndBlockTrigger -= BlockEnded;
    }

    private void Start()
    {
        block.StartBlock(OnEndBlockTrigger);
    }

    private void BlockEnded()
    {
        Debug.Log("Block ended");
    }

}

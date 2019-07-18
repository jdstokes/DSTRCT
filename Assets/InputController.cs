using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : Singleton<InputController>
{
    public Action OnTargetFound;

    public void TargetFound()
    {
        Debug.Log("Target Found");
        if (OnTargetFound != null)
        {
            OnTargetFound();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TargetFound();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{

    public Trial trials;
    Action endTrials;

    void Start()
    {
        trials.StartTrials(endTrials,2);
    }

}

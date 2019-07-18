
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;



public class Main : MonoBehaviour
{

    // Have Grid build follow start position
    // Pre block
    // - setup grid
    // - setup block parameters
    //      - number of distractors/grid
    //      - location of singleton distractor
    //      - percentage of sigleton distractor
    //      - number of trials

    [Header("Grid Settings")]
    public int x;
    public int y;
    public int z;
    public Transform playerTransform;
    public int numberOfVoxels;
    public float distanceFromPlayer = 3;

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

    //
    private List<Grid> _gridList;
    private List<GameObject> _distractorList;


    public void StartExperiment()
    {
        // Setup grid
        Vector3 startPosition = playerTransform.position;
        startPosition.z = startPosition.z + distanceFromPlayer;
        //_gridList = GridController.Instance.BuildGrids(
        //        startPosition, x, y, z, numberOfVoxels);

        //Start Block
        StartCoroutine(StartTask());
    }



    IEnumerator StartTask()
    {
        for(int i = 0; i< numberOfTrials; i++)
        {
            StartCoroutine(SpawnDistractors());
            yield return new WaitForSeconds(trialTime);
            StartCoroutine(DestroyDistractors());
            yield return new WaitForSeconds(itiTime);
        }
    }

    IEnumerator RunBlocks()
    {
        blockCount = 0;
        while (blockCount < numberOfBlocks)
        {
            yield return StartCoroutine(SetUpBlock());
            yield return StartCoroutine(StartBlock());
            yield return StartCoroutine(EndBlock());
            blockCount++;
            yield return null;
        }
    }

    IEnumerator RunTrials()
    {
        while (trialCount < numberOfBlocks)
        {
            yield return StartCoroutine(SetUpTrial());
            yield return StartCoroutine(StartTrial());
            yield return StartCoroutine(EndTrial());
            trialCount++;
            yield return null;
        }
    }

    IEnumerator SetUpTrial()
    {
        yield return null;
    }

    IEnumerator StartTrial()
    {
        StartCoroutine(SpawnDistractors());
        yield return null;
    }

    IEnumerator EndTrial()
    {
        StartCoroutine(DestroyDistractors());
        yield return null;
    }

    IEnumerator SetUpBlock()
    {
        yield return null;
    }

    IEnumerator StartBlock()
    {
        yield return null;
    }

    IEnumerator EndBlock()
    {
        yield return null;
    }

    IEnumerator SpawnDistractors()
    {
        _distractorList = new List<GameObject>();
        Grid grid = SelectGrid();
        for (int i = 0; i < numberOfDistractors; i++)
        {
            int rv = UnityEngine.Random.Range(0, grid.VoxelList.Count);
            Voxel voxel = grid.VoxelList[rv];
            GameObject newDistractor = Instantiate(distractor, new Vector3(voxel.X,voxel.Y,voxel.Z), Quaternion.identity);
        }

        Debug.Log(grid.GridID);
        Debug.Log("Spawn Distractors");
        yield return null;
    }

    private Grid SelectGrid()
    {
        int rb = UnityEngine.Random.Range(0, _gridList.Count);
        return _gridList[rb];
    }


    IEnumerator DestroyDistractors()
    {
        foreach (var distractor in _distractorList)
        {
            Destroy(distractor);
        }
        Debug.Log("Kill Distractors");
        yield return null;
    }

}

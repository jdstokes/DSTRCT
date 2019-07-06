
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

    [Header("Object Settings")]
    public GameObject distractor;


    private List<Grid> _gridList;

    public void StartExperiment()
    {

        // Setup grid
        Vector3 startPosition = playerTransform.position;
        startPosition.z = startPosition.z + distanceFromPlayer;
        _gridList = GridController.Instance.BuildGrids(
                startPosition, x, y, z, numberOfVoxels);

        //Start Block
        StartTask();
    }


    IEnumerator StartTask()
    {
        for(int i = 0; i<numberOfTrials; i++)
        {
            SpawnDistractors();
            yield return new WaitForSeconds(trialTime);
            DestroyDistractors();
            yield return new WaitForSeconds(itiTime);
        }

    }

    IEnumerator SpawnDistractors()
    {

        int rb = UnityEngine.Random.Range(0, _gridList.Count);
        Grid grid = _gridList[rb];
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

    IEnumerator DestroyDistractors()
    {
        Debug.Log("Kill Distractors");
        yield return null;
    }

}

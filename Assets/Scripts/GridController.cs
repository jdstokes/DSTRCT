using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : Singleton<GridController>
{

    [Header("Grid Settings")]
    public int x;
    public int y;
    public int z;
    public Transform playerTransform;
    public int numberOfVoxels;
    public float distanceFromPlayer;
    public List<Grid> gridList;
    public int fireInd;
    public List<int> nonFireIndList;
    public int numberOfDistractors = 3;
    public GameObject regularDistractor;
    public List<GameObject> regularDistractorList;
    public GameObject targetPrefab;
    private GameObject newTarget;
    public GameObject fireDistractorPrefab;

    public IEnumerator SetupGridList()
    {
        Vector3 startPosition = playerTransform.position;
        startPosition.z = startPosition.z + distanceFromPlayer;
        gridList = new List<Grid>();
        int gridID = 0;
        for (int ix = 0; ix < x; ix++)
        {
            for (int iy = 0; iy < y; iy++)
            {
                for (int iz = 0; iz < z; iz++)
                {
                    gridList.Add(new Grid(startPosition, ix, iy, iz, numberOfVoxels, gridID));
                    gridID++;
                    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //cube.transform.position = new Vector3(x, y, z);
                }
            }
        }
        yield return null;
    }

    public void SetupGridForTask()
    {
        StartCoroutine(SetupGridForTaskCo());
    }

    public void ResetGrid()
    {
        StartCoroutine(SetupGridList());
    }

    private IEnumerator SetupGridForTaskCo()
    {
        yield return StartCoroutine(SetupGridList());
        yield return StartCoroutine(SelectFireGrid());
    }

    private IEnumerator SelectFireGrid()
    {
        nonFireIndList = new List<int>();
        fireInd = UnityEngine.Random.Range(0, gridList.Count);

        for(int i = 0; i < gridList.Count; i++)
        {
            if (i != fireInd)
            {
                nonFireIndList.Add(i);
            }
        }
        yield return null;
    }

    public void SpawnRegularDistractors()
    {

        regularDistractorList = new List<GameObject>();

        foreach (int gridInd in nonFireIndList)
        {
            Grid grid = gridList[gridInd];
            int cnt = 0;
            while(cnt < numberOfDistractors)
            {
                int rv = UnityEngine.Random.Range(0, grid.VoxelList.Count);
                Voxel voxel = grid.VoxelList[rv];
                if (!voxel.isDistractor)
                {
                    GameObject newDistractor = Instantiate(regularDistractor, new Vector3(voxel.X, voxel.Y, voxel.Z), Quaternion.identity);
                    grid.VoxelList[rv].isDistractor = true;
                    regularDistractorList.Add(newDistractor);
                    cnt++;
                }
            }
        }
    }

    public void SpawnFireDistractor()
    {
        Grid grid = gridList[fireInd];
        int cnt = 0;
        while (cnt < numberOfDistractors)
        {
            int rv = UnityEngine.Random.Range(0, grid.VoxelList.Count);
            Voxel voxel = grid.VoxelList[rv];
            if (!voxel.isDistractor)
            {
                GameObject newDistractor = Instantiate(fireDistractorPrefab, new Vector3(voxel.X, voxel.Y, voxel.Z), Quaternion.identity);
                grid.VoxelList[rv].isDistractor = true;
                regularDistractorList.Add(newDistractor);
                cnt++;
            }
        }

    }

    public void RemoveDistractors()
    {
        foreach (var distractor in regularDistractorList)
        {
            Destroy(distractor);
        }
    }

    public void SpawnTarget()
    {
        StartCoroutine(SpawnTargetCo());
    }

    public void DestroyTarget()
    {
        Destroy(newTarget);
    }

    private IEnumerator SpawnTargetCo()
    {
        int cnt = 0;
        while (true)
        {
            cnt++;
            if(cnt > 100)
            {
                Debug.Log("Target not spawning");

                break;
            }
            // Random grid
            int gInd = UnityEngine.Random.Range(0, gridList.Count);
            Grid grid = gridList[gInd];

            // Random voxel
            int vInd = UnityEngine.Random.Range(0, grid.VoxelList.Count);
            Voxel voxel = grid.VoxelList[vInd];
            Vector3 targetPosition = new Vector3(voxel.X, voxel.Y, voxel.Z);

            if (voxel.isDistractor)
            {

                Debug.Log("voxel occupied with distractor " + targetPosition);
                continue;
            }

            newTarget = Instantiate(targetPrefab, targetPosition, Quaternion.identity);

            if (!IsTargetVisible(targetPosition))
            {
                Destroy(newTarget);
                continue;
            }

            break;
        }
        yield return null;

    }

    public bool IsTargetVisible(Vector3 targetPosition)
    {
        float maxRange = 1000;
        RaycastHit hit;
        Vector3 referencePosition = playerTransform.position;

     
            if (Physics.Raycast(targetPosition, (referencePosition - targetPosition), out hit, maxRange))
            {

                if (hit.transform.gameObject.tag == "Target")
                {
                    // In Range and i can see you!
                    Debug.Log("Player can see Target");
                    return true;

                }
                else
                {
                    Debug.Log("Player can not see Target");
                    return false;
                }
            }
            else
            {
                Debug.Log("Player can not see Target");
                return false;
            }
    }
 
    

}

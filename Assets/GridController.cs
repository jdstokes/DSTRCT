using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int X;
    public int Y;
    public int Z;

    public Transform startTransform;
    public List<Voxel> voxelList = new List<Voxel>();

    private void Start()
    {
        BuildGrid();
    }
    private void BuildGrid()
    {
        int numVoxels = (X + 1) * (Y + 1) * (Z + 1);

        for(int x =0; x < X; x++)
        {
            for (int y = 0; y < Y; y++)
            {
                for (int z = 0; z < Z; z++)
                {
                    voxelList.Add(new Voxel(x, y, z));
                }
            }
        }

    }
}

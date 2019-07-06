using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int X;
    public int Y;
    public int Z;
    public int GridID;
    public List<Voxel> VoxelList = new List<Voxel>();


    public Grid(Vector3 startPosition, int x, int y, int z,int numVoxelsInRow, int gridID)
    {
        X = x;
        Y = y;
        Z = z;
        GridID = gridID;

        // Create Grid parent
        GameObject gridParent = new GameObject("Grid" + gridID.ToString());

        for (int ix = x*numVoxelsInRow; ix < x*numVoxelsInRow + numVoxelsInRow; ix ++)
        {
            for (int iy = y*numVoxelsInRow; iy < y*numVoxelsInRow + numVoxelsInRow; iy++)
            {
                for (int iz = z*numVoxelsInRow; iz < z*numVoxelsInRow + numVoxelsInRow; iz++)
                {
                    float voxelX = startPosition.x + ix - numVoxelsInRow + .5f;
                    float voxelY = startPosition.y + iy;
                    float voxelZ = startPosition.z + iz;
                    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //cube.transform.position = new Vector3(voxelX, voxelY, voxelZ);
                    //cube.transform.SetParent(gridParent.transform);
                    VoxelList.Add(new Voxel(voxelX, voxelY, voxelZ));
                    //Renderer rend = cube.GetComponent<Renderer>();

                    //   Debug.Log("New voxel created: " + ix + "," + iy + "," + iz);
                    //Debug.Log(rend.bounds.extents);


                }
            }
        }
    }
}

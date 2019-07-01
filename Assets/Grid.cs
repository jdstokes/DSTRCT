using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel
{
    public int X;
    public int Y;
    public int Z;

    public Voxel(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        Debug.Log("New voxel created: " + x + "," + y + "," + z);
    }
}

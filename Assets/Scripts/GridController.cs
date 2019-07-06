using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : Singleton<GridController>
{

    public List<Grid> BuildGrids(Vector3 startPosition, int x, int y, int z, int numberOfVoxels)
    {

        List<Grid> gridList = new List<Grid>();
        int gridID = 0;
        for(int ix = 0; ix < x; ix++)
        {
            for (int iy = 0; iy < y; iy++)
            {
                for (int iz = 0; iz < z; iz++)
                {
                    gridList.Add(new Grid(startPosition,ix, iy, iz, numberOfVoxels, gridID));
                    gridID++;
                    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //cube.transform.position = new Vector3(x, y, z);
                }
            }
        }
        return gridList;
    }
}

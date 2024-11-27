using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPieceLogic : MonoBehaviour
{
    public Vector3 LastPositionInGrid;
    
    Vector3 RoundAxisValue(Vector3 position)
    {
        float x = Mathf.Round(position.x / GridManager.cellSize) * GridManager.cellSize;
        float y = Mathf.Round(position.y / GridManager.cellSize) * GridManager.cellSize;
        float z = Mathf.Round(position.z / GridManager.cellSize) * GridManager.cellSize;
        return new Vector3(x, y, z);
    }

    void GetGridCellPositions()
    {
        for (int x = 0; x < GridManager.gridSizeX; x++)
        {
            for (int y = 0; y < GridManager.gridSizeY; y++)
            {
                for (int z = 0; z < GridManager.gridSizeZ; z++)
                {
                    if (GridManager.grid[x, y, z].position == transform.position)
                    {
                        LastPositionInGrid = new Vector3(x, y, z);
                    }
                }
            }
        }
    }
    public Vector3 GetGridPosition()
    {
        return RoundAxisValue(transform.position);
    }
}
 
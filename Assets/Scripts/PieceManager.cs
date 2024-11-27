using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] GameObject basicCube;
    [SerializeField] GridManager gridManager;
    [SerializeField] Material puzzleMat;
    [SerializeField] Material piecesMaterial;
    [SerializeField] Color[] piecesColors;
    public bool[,,] LShapePiece = new bool[,,]
    {
        { { false, true, true }, { false, true, false }, { false, true, false } }
    };
    public bool[,,] IShapePiece = new bool[,,]
    {
        { { false, true, false }, { false, true, false }, { false, true, false } }
    };
    public bool[,,] TShapePiece = new bool[,,]
    {
        { { false, false, false }, { false, true, false }, { true, true, true } }
    };
    public bool[,,] CubeShapePiece = new bool[,,]
    {
        { { true, true, false }, { true, true, false }, { false, false, false } }
    };
    public bool[,,] SShapePiece = new bool[,,]
    {
        { { true, true, false }, { false, true, false }, { false, true, true } }
    };
    public bool[,,] JShapePiece = new bool[,,]
    {
        { { true, true, false }, { false, true, false }, { true, true, true } }
    };
    public bool[,,] HShapePiece = new bool[,,]
    {
        { { true, false, true }, { true, true, true }, { true, false, true } }
    };

    private List<bool[,,]> pieceLibrary;

    private void Start()
    {
        pieceLibrary = new List<bool[,,]> { LShapePiece, IShapePiece, TShapePiece, CubeShapePiece, SShapePiece, JShapePiece, HShapePiece };

        // Ensure GridManager is initialized
        if (gridManager == null)
        {
            Debug.LogError("GridManager is not assigned.");
            return;
        }

        
    }

    public void SpawnPiece(bool[,,] pieceConfig, string pieceName, Vector3 spawnPosition)
    {
        GameObject pieceParent = new GameObject(pieceName);
        pieceParent.transform.position = GridManager.SnapToGrid(spawnPosition);
        pieceParent.AddComponent<PieceParentController>();

        for (int x = 0; x < pieceConfig.GetLength(0); x++)
        {
            for (int y = 0; y < pieceConfig.GetLength(1); y++)
            {
                for (int z = 0; z < pieceConfig.GetLength(2); z++)
                {
                    if (pieceConfig[x, y, z])
                    {
                        Vector3 cubePosition = new Vector3(x * GridManager.cellSize, y * GridManager.cellSize, z * GridManager.cellSize);
                        GameObject cube = Instantiate(basicCube, cubePosition, Quaternion.identity);
                        Renderer cubemat =cube.GetComponent<Renderer>();
                        cubemat.material = piecesMaterial;
                        cube.transform.SetParent(pieceParent.transform);
                        if (pieceName == "LShapeCard") { cubemat.material.color = piecesColors[0]; }
                        else if (pieceName == "IShapeCard") { cubemat.material.color = piecesColors[1]; }
                        else if (pieceName == "TShapeCard") { cubemat.material.color = piecesColors[2]; }
                        else if (pieceName == "CubeShapeCard") { cubemat.material.color = piecesColors[3]; }
                        else if (pieceName == "SShapeCard") { cubemat.material.color = piecesColors[4]; }
                        else if (pieceName == "JShapeCard") { cubemat.material.color = piecesColors[5]; }
                        else if (pieceName == "HShapeCard") { cubemat.material.color = piecesColors[6]; }
                    }
                }
            }
        }
    }

    public void GeneratePuzzleShape()
    {
        GridManager.puzzleGrid = new bool[GridManager.puzzleGridSizeX, GridManager.puzzleGridSizeY, GridManager.puzzleGridSizeZ];
        Vector3 currentPos = new Vector3(GridManager.puzzleGridSizeX / 2, 0, GridManager.puzzleGridSizeZ / 2);
        foreach (var piece in pieceLibrary)
        {
            if (TryPlacePieceInPuzzleGrid(piece, currentPos))
            {
                currentPos += new Vector3(1, 0, 0); // Adjust position for more spacing
            }
        }
        DisplayPuzzleReference(); // Show the blacked-out visual representation of the puzzle
    }

    private bool TryPlacePieceInPuzzleGrid(bool[,,] piece, Vector3 origin)
    {
        for (int x = 0; x < piece.GetLength(0); x++)
        {
            for (int y = 0; y < piece.GetLength(1); y++)
            {
                for (int z = 0; z < piece.GetLength(2); z++)
                {
                    int gridX = Mathf.FloorToInt(origin.x) + x;
                    int gridY = Mathf.FloorToInt(origin.y) + y;
                    int gridZ = Mathf.FloorToInt(origin.z) + z;
                    if (piece[x, y, z] && IsOccupied(gridX, gridY, gridZ))
                    {
                        return false; // Position is not valid
                    }
                }
            }
        }

        // Place piece in grid
        for (int x = 0; x < piece.GetLength(0); x++)
        {
            for (int y = 0; y < piece.GetLength(1); y++)
            {
                for (int z = 0; z < piece.GetLength(2); z++)
                {
                    int gridX = Mathf.FloorToInt(origin.x) + x;
                    int gridY = Mathf.FloorToInt(origin.y) + y;
                    int gridZ = Mathf.FloorToInt(origin.z) + z;
                    if (piece[x, y, z])
                    {
                        GridManager.puzzleGrid[gridX, gridY, gridZ] = true;
                    }
                }
            }
        }
        return true;
    }

    private bool IsOccupied(int x, int y, int z)
    {
        if (x >= 0 && x < GridManager.puzzleGridSizeX && y >= 0 && y < GridManager.puzzleGridSizeY && z >= 0 && z < GridManager.puzzleGridSizeZ)
        {
            return GridManager.puzzleGrid[x, y, z];
        }
        return true;
    }

    private void DisplayPuzzleReference()
    {
        for (int x = 0; x < GridManager.puzzleGridSizeX; x++)
        {
            for (int y = 0; y < GridManager.puzzleGridSizeY; y++)
            {
                for (int z = 0; z < GridManager.puzzleGridSizeZ; z++)
                {
                    if (GridManager.puzzleGrid[x, y, z])
                    {
                        Vector3 cellPosition = new Vector3(x, y, z) * GridManager.cellSize;
                        GameObject blackCube = Instantiate(basicCube, cellPosition, Quaternion.identity);
                        blackCube.GetComponent<Renderer>().material = puzzleMat;
                        blackCube.transform.localScale = transform.localScale * 0.07f;
                        blackCube.tag = "Untagged";
                    }
                }
            }
        }
    }
}

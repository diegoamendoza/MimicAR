    using System.Collections;
    using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public class GridManager : MonoBehaviour
    {
        public static int gridSizeX =6, gridSizeY=6, gridSizeZ=6; 
        public static int puzzleGridSizeX = 5, puzzleGridSizeY = 5, puzzleGridSizeZ = 5;
        public static float cellSize=0.1f;
        public static bool[,,] puzzleGrid;
        public static GridCell[,,] grid;
        [SerializeField] GameObject vizualizationCube;
        [SerializeField] Color[] testColor;
        [SerializeField] PieceManager pieceManager;
    public static bool gameEnded=false;
    private void Awake()
    {
        InitializePlayerGrid();
        InitializePuzzleGrid();
    }
    void Start()
        {
       
        pieceManager.GeneratePuzzleShape();
        }
    
    
    private void Update()
    {
        if (ValidatePuzzleCompletion()) { gameEnded = true; }
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    if(!grid[x,y,z].filled)
                    {
                      Material cubemat = grid[x, y, z].cellCube.GetComponent<Renderer>().material;
                        cubemat.color = testColor[0];
                    }
                    else
                    {
                        Material cubemat = grid[x, y, z].cellCube.GetComponent<Renderer>().material;
                        cubemat.color = testColor[1];
                    }
                }
            }
        }
    }private void InitializePlayerGrid()
    {
        grid = new GridCell[gridSizeX, gridSizeY, gridSizeZ];
        
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                for (int z = 0; z < gridSizeZ; z++)
                {
                    Vector3 cellPosition = new Vector3(x, y, z) * cellSize;
                    GameObject cellVisu = Instantiate(vizualizationCube, cellPosition, Quaternion.identity);
                    grid[x, y, z] = new GridCell(cellPosition, null, Quaternion.identity, false, cellVisu);
                }
            }
        }
    }
    private void InitializePuzzleGrid()
    {
        puzzleGrid = new bool[puzzleGridSizeX, puzzleGridSizeY, puzzleGridSizeZ];
    }
    public static bool IsValidGridPosition(Vector3 position)
    {
        for (int x = 0; x < GridManager.gridSizeX; x++)
        {
            for (int y = 0; y < GridManager.gridSizeY; y++)
            {
                for (int z = 0; z < GridManager.gridSizeZ; z++)
                {
                    if(position.x>=0&&position.x <= grid[x, y, z].position.x &&
                        position.y >= 0 && position.y <= grid[x, y, z].position.y
                        && position.z >= 0 && position.z <= grid[x, y, z].position.z)
                        return true;
                }
            }
        }
        return false;
    }
    public static bool ValidatePuzzleCompletion()
    {
        for (int x = 0; x < puzzleGridSizeZ; x++)
        {
            for (int y = 0; y < puzzleGridSizeZ; y++)
            {
                for (int z = 0; z < puzzleGridSizeZ; z++)
                {
                    if (puzzleGrid[x, y, z]!=grid[x, y, z].filled)
                    {
                       // Debug.Log("PAPUUUU FALLAS");
                        return false; // Grids do not match
                    }
                }
            }
        }
        return true; // Puzzle is solved
    }
    public static Vector3 SnapToGrid(Vector3 position)
    {
        float x = Mathf.Round(position.x / GridManager.cellSize) * GridManager.cellSize;
        float y = Mathf.Round(position.y / GridManager.cellSize) * GridManager.cellSize;
        float z = Mathf.Round(position.z / GridManager.cellSize) * GridManager.cellSize;

        return new Vector3(x, y, z);
    }
}

    public class GridCell
    {
        public Vector3 position;
        public GameObject piece;
        public Quaternion orientation;
        public bool filled;
        public GameObject cellCube;

        public GridCell(Vector3 pos, GameObject p, Quaternion orient,bool fill,GameObject cellCub)
        {
            position = pos;
            piece = p;
            orientation = orient;
            filled = fill;
        cellCube = cellCub;
        }
    }


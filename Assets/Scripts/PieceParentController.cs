using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PieceParentController : MonoBehaviour
{
    [SerializeField]BasicPieceLogic[] pieceLogics;
    [SerializeField] Vector3[] piecePositionsInGrid;
    KeyBoardControls keyboardCtrls;
    

    private void Start()
    {
        //keyboardCtrls = new KeyBoardControls();
        //keyboardCtrls.Enable();
        //keyboardCtrls.HorizontalControl.RightAndLeft.performed += OnHorizontalMove;
        //keyboardCtrls.VerticalControl.UpAndDown.performed += OnVerticalMove;
        //keyboardCtrls.DepthControl.BackAndFoward.performed += OnDepthMove;
        ////////////////////////////////////////////////////////////////////////////
        pieceLogics = GetComponentsInChildren<BasicPieceLogic>();
        piecePositionsInGrid = new Vector3[pieceLogics.Length];
        for (int i = 0; i < pieceLogics.Length; i++)
        {
            piecePositionsInGrid[i] = pieceLogics[i].GetGridPosition();
        }
        
    }

    private void Update()
    {
        UpdateGridCells(true);
    }
    public void OnHorizontalMove(float direction)
    {
        Vector3 moveVector = Vector3.right * direction; 
        MovePiece(moveVector);
        transform.position = RoundAxisValue(transform.position);
    }

    public void OnVerticalMove(float direction)
    {

        Vector3 moveVector = Vector3.up * direction;
        MovePiece(moveVector);
        transform.position= RoundAxisValue(transform.position);
    }

    public void OnDepthMove(float direction)
    {

        Vector3 moveVector = Vector3.forward * direction;
        MovePiece(moveVector);
        transform.position = RoundAxisValue(transform.position);
    }
    public void MovePiece(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction * GridManager.cellSize;
        //Debug.Log(newPosition);
        if (IsPositionValid(newPosition))
        {
            //Debug.Log("VALID");
            UpdateGridCells(false);
            transform.position = newPosition; 
            transform.position = RoundAxisValue(transform.position);
            UpdateGridCells(true);
        }
        //else Debug.Log("NOT VALID");
    }

    private bool IsPositionValid(Vector3 newPosition)
    {
        foreach (var pieceLogic in pieceLogics)
        {
            Vector3 newPiecePos = newPosition + pieceLogic.transform.localPosition;
            if (!GridManager.IsValidGridPosition(newPiecePos))
                return false;
        }
        return true;
    }

    private void UpdateGridCells(bool fill)
    {
        for (int x = 0; x < GridManager.gridSizeX; x++)
        {
            for (int y = 0; y < GridManager.gridSizeY; y++)
            {
                for (int z = 0; z < GridManager.gridSizeZ; z++)
                {
                    for (int i = 0; i < pieceLogics.Length; i++)
                    {
                        piecePositionsInGrid[i] = pieceLogics[i].GetGridPosition();
                        if (GridManager.grid[x, y, z].position == piecePositionsInGrid[i])
                        {
                            GridManager.grid[x, y, z].filled = fill;
                        }

                    }
                   
                }
            }
        }
       
    }
    Vector3 RoundAxisValue(Vector3 position)
    {
        float x = Mathf.Round(position.x / GridManager.cellSize) * GridManager.cellSize;
        float y = Mathf.Round(position.y / GridManager.cellSize) * GridManager.cellSize;
        float z = Mathf.Round(position.z / GridManager.cellSize) * GridManager.cellSize;
        return new Vector3(x, y, z);
    }
    private void OnDestroy()
    {
        foreach (Vector3 piece in piecePositionsInGrid) 
        {
            //Debug.Log("changing values" + piece);
            for (int x = 0; x < GridManager.gridSizeX; x++)
            {
                for (int y = 0; y < GridManager.gridSizeY; y++)
                {
                    for (int z = 0; z < GridManager.gridSizeZ; z++)
                    {
                        if (GridManager.grid[x, y, z].position == piece)
                        {
                            GridManager.grid[x, y, z].filled = false;
                        }

                    }
                }
            }
        }
        if (gameObject.name == "LShapeCard") { CostsManager.SubtractUsedPoints(15); }
        if (gameObject.name == "IShapeCard") { CostsManager.SubtractUsedPoints(30); }
        else if (gameObject.name == "TShapeCard") { CostsManager.SubtractUsedPoints(20); }
        else if (gameObject.name == "CubeShapeCard") { CostsManager.SubtractUsedPoints(50); }
        else if (gameObject.name == "SShapeCard") { CostsManager.SubtractUsedPoints(25); }
        else if (gameObject.name == "JShapeCard") { CostsManager.SubtractUsedPoints(10); }
        else if (gameObject.name == "HShapeCard") { CostsManager.SubtractUsedPoints(15); }
    }
}

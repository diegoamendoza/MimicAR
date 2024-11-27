using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CostsManager : MonoBehaviour
{
    
    public static int totalPoints=9999, usedPoints=0;
    public static bool canSpawnPieces;

    private void Update()
    {
       // Debug.Log(usedPoints);
    }
    public static void SetTotalPoints(int value) 
    {
        totalPoints = value;
    }
    public static void AddUsedPoints(int value)
    {
        usedPoints += value;
    }
    public static void SubtractUsedPoints(int value)
    {
        usedPoints -= value;
    }
}

using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class ArScanScript : MonoBehaviour
{
    private ARTrackedImageManager _trackedImagesManager;
    public PieceManager pieceManager;
    private Dictionary<string, bool[,,]> _pieceMappings;
    private Dictionary<string, float> _lastSpawnTime;
    public float spawnCooldown = 5f; // Cooldown time in seconds

    void Awake()
    {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
        _pieceMappings = new Dictionary<string, bool[,,]>
        {
            { "LShapeCard", pieceManager.LShapePiece },
            { "IShapeCard", pieceManager.IShapePiece },
            { "TShapeCard", pieceManager.TShapePiece },
            { "CubeShapeCard", pieceManager.CubeShapePiece },
            { "SShapeCard", pieceManager.SShapePiece },
            { "JShapeCard", pieceManager.JShapePiece },
            { "HShapeCard", pieceManager.HShapePiece }
        };
        _lastSpawnTime = new Dictionary<string, float>();
    }

    private void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            HandleTrackedImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            HandleTrackedImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            Destroy(trackedImage.gameObject);
        }
    }

    private void HandleTrackedImage(ARTrackedImage trackedImage)
    {
        string imageName = trackedImage.referenceImage.name;
        
            if (_pieceMappings.ContainsKey(imageName))
            {
                if (!_lastSpawnTime.ContainsKey(imageName) || Time.time - _lastSpawnTime[imageName] >= spawnCooldown)
                {
                    bool[,,] pieceConfig = _pieceMappings[imageName];
                    Vector3 spawnPosition = trackedImage.transform.position;

                    if (imageName == "LShapeCard")
                    {
                        if (CostsManager.usedPoints + 15 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time;
                            CostsManager.AddUsedPoints(15);
                        }
                    }
                    if (imageName == "IShapeCard")
                    {
                        if (CostsManager.usedPoints + 30 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time; CostsManager.AddUsedPoints(30);
                        }
                    }
                    else if (imageName == "TShapeCard")
                    {
                        if (CostsManager.usedPoints + 20 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time; CostsManager.AddUsedPoints(20);
                        }
                    }
                    else if (imageName == "CubeShapeCard")
                    {
                        if (CostsManager.usedPoints + 50 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time; CostsManager.AddUsedPoints(50);
                        }
                    }
                    else if (imageName == "SShapeCard")
                    {
                        if (CostsManager.usedPoints + 25 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time; CostsManager.AddUsedPoints(25);
                        }
                    }
                    else if (imageName == "JShapeCard")
                    {
                        if (CostsManager.usedPoints + 10 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time; CostsManager.AddUsedPoints(10);
                        }
                    }
                    else if (imageName == "HShapeCard")
                    {
                        if (CostsManager.usedPoints + 15 <= CostsManager.totalPoints)
                        {
                            pieceManager.SpawnPiece(pieceConfig, imageName, spawnPosition);
                            _lastSpawnTime[imageName] = Time.time; CostsManager.AddUsedPoints(15);
                        }
                    }
                }
                else
                {
                    //Debug.Log("Cooldown active. Cannot spawn piece yet.");
                }
            }
       
    }
}

using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SwitchToFrontCamera : MonoBehaviour
{
    private ARCameraManager arCameraManager;

    void Start()
    {
        arCameraManager = GetComponent<ARCameraManager>();

        if (arCameraManager != null)
        {
            if (arCameraManager.requestedFacingDirection != CameraFacingDirection.User)
            {
                // Cambiar a la cámara frontal
                arCameraManager.requestedFacingDirection = CameraFacingDirection.User;
            }
			else
			{
                arCameraManager.requestedFacingDirection = CameraFacingDirection.World;
            }
        }
    }
}
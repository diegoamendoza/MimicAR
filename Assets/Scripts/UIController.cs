using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using System.Collections;
using UnityEngine.XR.Management;
public class UIController : MonoBehaviour
{

    public Transform cameraTransform;
    private Quaternion initialCameraRotation;
    /*******/
    [SerializeField] TextMeshProUGUI costsText;
    [SerializeField] ParticleSystem[] confettiPartcl;
    [SerializeField] AudioSource yaySound;
    bool victoryAnimationPlayed;
    [SerializeField]Animator victoryAnimator;
    /************/
    public ARSession arSession;
    public ARCameraManager arCameraManager;
    public ARPlaneManager arPlaneManager;
    public ARTrackedImageManager arTrackedImageManager;
    

    private void Start()
    {
        TouchDragManager.selectedObject = null; 
        initialCameraRotation = cameraTransform.rotation;
    }
    private void Update()
    {
        if(GridManager.gameEnded)
        {
            victoryAnimator.SetBool("victoryUIEnabled",true);
            if (!victoryAnimationPlayed)
            {
                yaySound.Play(); 
                for (int i = 0; i < confettiPartcl.Length; i++)
                confettiPartcl[i].Play();
                victoryAnimationPlayed = true;
            }
            
        }
    }
    private void OnGUI()
    {
        costsText.text = 1000 + " / " + CostsManager.usedPoints;
    }
    private Vector3 GetRelativeDirection(Vector3 direction)
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        Vector3 up = cameraTransform.up;
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();
        up.Normalize();
        float forwardDot = Vector3.Dot(direction, forward);
        float rightDot = Vector3.Dot(direction, right);
        float upDot = Vector3.Dot(direction, up);
        if (Mathf.Abs(forwardDot) > Mathf.Abs(rightDot) && Mathf.Abs(forwardDot) > Mathf.Abs(upDot))
        {
            return forwardDot > 0 ? forward : -forward;
        }
        else if (Mathf.Abs(rightDot) > Mathf.Abs(forwardDot) && Mathf.Abs(rightDot) > Mathf.Abs(upDot))
        {
            return rightDot > 0 ? right : -right;
        }
        else
        {
            return upDot > 0 ? up : -up;
        }
    }


    public void MoveUp()
    {
        if (TouchDragManager.selectedObject != null)
        {
            
            PieceParentController pieceParentController = TouchDragManager.selectedObject.GetComponent<PieceParentController>();

            //pieceParentController.MovePiece(GetRelativeDirection(cameraTransform.up));
            pieceParentController.MovePiece(Vector3.up);
        }
        else TouchDragManager.selectedObject = null;

    }

    public void MoveDown()
    {
        if (TouchDragManager.selectedObject != null)
        {
            
            PieceParentController pieceParentController = TouchDragManager.selectedObject.GetComponent<PieceParentController>();

            //pieceParentController.MovePiece(GetRelativeDirection(-cameraTransform.up)); 
            pieceParentController.MovePiece(Vector3.down);
        }
        else TouchDragManager.selectedObject = null;
    }

    public void MoveLeft()
    {
        if (TouchDragManager.selectedObject != null)
        {
            
            PieceParentController pieceParentController = TouchDragManager.selectedObject.GetComponent<PieceParentController>();

            //pieceParentController.MovePiece(GetRelativeDirection(cameraTransform.right)); 
            pieceParentController.MovePiece(Vector3.left);
        }
        else TouchDragManager.selectedObject = null;
    }

    public void MoveRight()
    {
        
        if (TouchDragManager.selectedObject != null)
        {
            
            PieceParentController pieceParentController = TouchDragManager.selectedObject.GetComponent<PieceParentController>();

            //pieceParentController.MovePiece(GetRelativeDirection(cameraTransform.right));
            pieceParentController.MovePiece(Vector3.right);
        }
        else TouchDragManager.selectedObject = null;
    }

    public void MoveForward()
    {
        
        if (TouchDragManager.selectedObject != null)
        {
            
            PieceParentController pieceParentController = TouchDragManager.selectedObject.GetComponent<PieceParentController>();

            //pieceParentController.MovePiece(GetRelativeDirection(cameraTransform.forward));
            pieceParentController.MovePiece(Vector3.forward);
        }
        else TouchDragManager.selectedObject = null;
    }

    public void MoveBackward()
    {
        
        if (TouchDragManager.selectedObject != null)
        {
            
            PieceParentController pieceParentController = TouchDragManager.selectedObject.GetComponent<PieceParentController>();

            //pieceParentController.MovePiece(GetRelativeDirection(-cameraTransform.forward));
            pieceParentController.MovePiece(-Vector3.forward);
        }
        else TouchDragManager.selectedObject = null;
    }
    public void ReciclePiece()
    {
        if (TouchDragManager.selectedObject != null)
        {
            Destroy(TouchDragManager.selectedObject.gameObject);
                
            TouchDragManager.selectedObject = null;
        }
    }
    public void RestartGame()
    {
        StartCoroutine(ResetAndReloadScene());
    }

    private IEnumerator ResetAndReloadScene()
    {
        // Disable AR Session and XR management
        if (arSession != null) arSession.enabled = false;

        // Disable all AR Managers
        if (arCameraManager != null) arCameraManager.enabled = false;
        if (arPlaneManager != null) arPlaneManager.enabled = false;
        if (arTrackedImageManager != null) arTrackedImageManager.enabled = false;

        // Stop XR subsystems
        var xrManagerSettings = XRGeneralSettings.Instance.Manager;
        if (xrManagerSettings.isInitializationComplete)
        {
            xrManagerSettings.DeinitializeLoader();
        }

        yield return new WaitForSeconds(0.5f); // Wait for resources to clear

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //void function(Action<float> function, float value)
    //{
    //    if (TouchDragManager.selectedObject != null)
    //    {
    //        selectedPiece = TouchDragManager.selectedObject;
    //        PieceParentController pieceParentController = selectedPiece.GetComponent<PieceParentController>();

    //        pieceParentController.function(value);
    //    }
    //    else selectedPiece = null;
    //} TAREA PA ALGUN DIA, DESCUBRIR COMO HACER FUNCIONAR LA LINEA .function(value);(hacer funcionar funciones con valores para hacerce una plantilla y ahorrar time)
}

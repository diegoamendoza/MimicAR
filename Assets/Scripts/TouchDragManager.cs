using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TouchDragManager : MonoBehaviour
{
    public static GameObject selectedObject;
    public TextMeshProUGUI text;
    [SerializeField] Animator hudAnimator;
    public static bool touchInteractedWithUI; 
    [SerializeField] List<RectTransform> buttons;

    private void OnEnable()
    {
        InputManager.Instance.OnStartTouch += OnTouchStarted;
        InputManager.Instance.OnEndTouch += OnTouchEnded;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnStartTouch -= OnTouchStarted;
        InputManager.Instance.OnEndTouch -= OnTouchEnded;
    }
    private void Update()
    {
        
        Debug.Log(GridManager.gameEnded);
        if (selectedObject != null)
        {
            //text.text = selectedObject.name;
            hudAnimator.SetBool("hudEnable", true);

        }
        else
        {
            //text.text = "None"; 
            hudAnimator.SetBool("hudEnable", false);
        }
        //text.text = GridManager.gameEnded.ToString();
    }
    private void OnTouchStarted(Vector2 screenPosition, float time)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition); 
        bool buttonTouched = false;
        RaycastHit hit; foreach (RectTransform button in buttons)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(button, screenPosition, Camera.main))
            { buttonTouched = true; }
            if (!buttonTouched)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Piece"))
                    {
                        selectedObject = hit.transform.parent.gameObject;
                        // Debug.Log("Object selected: " + selectedObject.name);

                    }
                }
                break;
            }
            
        }
        
            
    }

    private void OnTouchEnded(Vector2 screenPosition, float time)
    {
        bool buttonTouched = false;
        foreach (RectTransform button in buttons)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(button, screenPosition, Camera.main))
            {
                touchInteractedWithUI = true;
                buttonTouched = true;
               // Debug.Log("Button touched: " + button.name);
                break;
            }
        }

        if (!buttonTouched)
        {
            touchInteractedWithUI = false;
        }

        Ray rayui = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hitui;
        if (Physics.Raycast(rayui, out hitui) && !touchInteractedWithUI)
        {
            if (!hitui.collider.CompareTag("Piece"))
            {
               // Debug.Log("TOCO ALGO QUE NO ES UNA PIEZA");
                selectedObject = null;
            }
        }
        if(!Physics.Raycast(rayui)&&!touchInteractedWithUI)
        {
            selectedObject = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;
        if (!touchInteractedWithUI)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Piece"))
                {
                    selectedObject = hit.transform.parent.gameObject;
                    Debug.Log("Object still selected: " + selectedObject.name);
                }
            }
        }
    }

}

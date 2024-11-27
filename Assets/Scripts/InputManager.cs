using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    TouchControls touchControls;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    public delegate void MoveTouchEvent(Vector2 position, float time);
    public event MoveTouchEvent OnMoveTouch; 

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchDrag.performed += ctx => MoveTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }


    private void StartTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("Touch started");
        if (OnStartTouch != null)
        {
            OnStartTouch(touchControls.Touch.TouchDrag.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("Touch ended");
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControls.Touch.TouchDrag.ReadValue<Vector2>(), (float)context.time);
        }
    }

    private void MoveTouch(InputAction.CallbackContext context)
    {
       // Debug.Log("Touch is moving");
        if (OnMoveTouch != null)
        {
            OnMoveTouch(touchControls.Touch.TouchDrag.ReadValue<Vector2>(), Time.time);
        }
    }
}

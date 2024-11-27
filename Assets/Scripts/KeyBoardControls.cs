//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.2
//     from Assets/Scripts/Tests/KeyBoardControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine;

public partial class @KeyBoardControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeyBoardControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""KeyBoardControls"",
    ""maps"": [
        {
            ""name"": ""VerticalControl"",
            ""id"": ""7c1a42f6-8a14-4949-80d6-67e1bc074e46"",
            ""actions"": [
                {
                    ""name"": ""UpAndDown"",
                    ""type"": ""Button"",
                    ""id"": ""44f7a33e-3f50-4814-bcb3-ba8ad5ae7175"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""6e30b6fa-242f-4f6a-a94f-170d60ee4ed8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpAndDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""221837fc-bcb2-4acd-9f99-e8ad4e041d81"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpAndDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""29f115c4-0a2d-4e5e-8c9f-73b9975a6bcc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpAndDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""HorizontalControl"",
            ""id"": ""2f9e116e-127d-4360-a443-9b16fb4b3aab"",
            ""actions"": [
                {
                    ""name"": ""RightAndLeft"",
                    ""type"": ""Button"",
                    ""id"": ""21b68cbe-effd-44ff-9661-8bf675348a3e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""007f3151-7037-4c9f-9a2f-3b251fe2d963"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAndLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a1b4206a-dd0d-47c9-a37d-b92887ad8cff"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAndLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""08fa3540-01a8-41bd-99d0-5fb0ed359365"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightAndLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""DepthControl"",
            ""id"": ""4222e9eb-f08e-44b5-857f-6705cc388a9e"",
            ""actions"": [
                {
                    ""name"": ""BackAndFoward"",
                    ""type"": ""Button"",
                    ""id"": ""5f7bb2db-1b26-48bd-b3ec-f7299b2e1510"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""62091a1d-6bb3-404e-9221-710d83072e0a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackAndFoward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""805c808e-ad3f-43b0-a527-184c5a05c4e4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackAndFoward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2c3ff8be-d489-4575-ae89-3446478e611d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackAndFoward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // VerticalControl
        m_VerticalControl = asset.FindActionMap("VerticalControl", throwIfNotFound: true);
        m_VerticalControl_UpAndDown = m_VerticalControl.FindAction("UpAndDown", throwIfNotFound: true);
        // HorizontalControl
        m_HorizontalControl = asset.FindActionMap("HorizontalControl", throwIfNotFound: true);
        m_HorizontalControl_RightAndLeft = m_HorizontalControl.FindAction("RightAndLeft", throwIfNotFound: true);
        // DepthControl
        m_DepthControl = asset.FindActionMap("DepthControl", throwIfNotFound: true);
        m_DepthControl_BackAndFoward = m_DepthControl.FindAction("BackAndFoward", throwIfNotFound: true);
    }

    ~@KeyBoardControls()
    {
        Debug.Assert(!m_VerticalControl.enabled, "This will cause a leak and performance issues, KeyBoardControls.VerticalControl.Disable() has not been called.");
        Debug.Assert(!m_HorizontalControl.enabled, "This will cause a leak and performance issues, KeyBoardControls.HorizontalControl.Disable() has not been called.");
        Debug.Assert(!m_DepthControl.enabled, "This will cause a leak and performance issues, KeyBoardControls.DepthControl.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // VerticalControl
    private readonly InputActionMap m_VerticalControl;
    private List<IVerticalControlActions> m_VerticalControlActionsCallbackInterfaces = new List<IVerticalControlActions>();
    private readonly InputAction m_VerticalControl_UpAndDown;
    public struct VerticalControlActions
    {
        private @KeyBoardControls m_Wrapper;
        public VerticalControlActions(@KeyBoardControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpAndDown => m_Wrapper.m_VerticalControl_UpAndDown;
        public InputActionMap Get() { return m_Wrapper.m_VerticalControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VerticalControlActions set) { return set.Get(); }
        public void AddCallbacks(IVerticalControlActions instance)
        {
            if (instance == null || m_Wrapper.m_VerticalControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VerticalControlActionsCallbackInterfaces.Add(instance);
            @UpAndDown.started += instance.OnUpAndDown;
            @UpAndDown.performed += instance.OnUpAndDown;
            @UpAndDown.canceled += instance.OnUpAndDown;
        }

        private void UnregisterCallbacks(IVerticalControlActions instance)
        {
            @UpAndDown.started -= instance.OnUpAndDown;
            @UpAndDown.performed -= instance.OnUpAndDown;
            @UpAndDown.canceled -= instance.OnUpAndDown;
        }

        public void RemoveCallbacks(IVerticalControlActions instance)
        {
            if (m_Wrapper.m_VerticalControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVerticalControlActions instance)
        {
            foreach (var item in m_Wrapper.m_VerticalControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VerticalControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VerticalControlActions @VerticalControl => new VerticalControlActions(this);

    // HorizontalControl
    private readonly InputActionMap m_HorizontalControl;
    private List<IHorizontalControlActions> m_HorizontalControlActionsCallbackInterfaces = new List<IHorizontalControlActions>();
    private readonly InputAction m_HorizontalControl_RightAndLeft;
    public struct HorizontalControlActions
    {
        private @KeyBoardControls m_Wrapper;
        public HorizontalControlActions(@KeyBoardControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightAndLeft => m_Wrapper.m_HorizontalControl_RightAndLeft;
        public InputActionMap Get() { return m_Wrapper.m_HorizontalControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HorizontalControlActions set) { return set.Get(); }
        public void AddCallbacks(IHorizontalControlActions instance)
        {
            if (instance == null || m_Wrapper.m_HorizontalControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_HorizontalControlActionsCallbackInterfaces.Add(instance);
            @RightAndLeft.started += instance.OnRightAndLeft;
            @RightAndLeft.performed += instance.OnRightAndLeft;
            @RightAndLeft.canceled += instance.OnRightAndLeft;
        }

        private void UnregisterCallbacks(IHorizontalControlActions instance)
        {
            @RightAndLeft.started -= instance.OnRightAndLeft;
            @RightAndLeft.performed -= instance.OnRightAndLeft;
            @RightAndLeft.canceled -= instance.OnRightAndLeft;
        }

        public void RemoveCallbacks(IHorizontalControlActions instance)
        {
            if (m_Wrapper.m_HorizontalControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IHorizontalControlActions instance)
        {
            foreach (var item in m_Wrapper.m_HorizontalControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_HorizontalControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public HorizontalControlActions @HorizontalControl => new HorizontalControlActions(this);

    // DepthControl
    private readonly InputActionMap m_DepthControl;
    private List<IDepthControlActions> m_DepthControlActionsCallbackInterfaces = new List<IDepthControlActions>();
    private readonly InputAction m_DepthControl_BackAndFoward;
    public struct DepthControlActions
    {
        private @KeyBoardControls m_Wrapper;
        public DepthControlActions(@KeyBoardControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @BackAndFoward => m_Wrapper.m_DepthControl_BackAndFoward;
        public InputActionMap Get() { return m_Wrapper.m_DepthControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DepthControlActions set) { return set.Get(); }
        public void AddCallbacks(IDepthControlActions instance)
        {
            if (instance == null || m_Wrapper.m_DepthControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DepthControlActionsCallbackInterfaces.Add(instance);
            @BackAndFoward.started += instance.OnBackAndFoward;
            @BackAndFoward.performed += instance.OnBackAndFoward;
            @BackAndFoward.canceled += instance.OnBackAndFoward;
        }

        private void UnregisterCallbacks(IDepthControlActions instance)
        {
            @BackAndFoward.started -= instance.OnBackAndFoward;
            @BackAndFoward.performed -= instance.OnBackAndFoward;
            @BackAndFoward.canceled -= instance.OnBackAndFoward;
        }

        public void RemoveCallbacks(IDepthControlActions instance)
        {
            if (m_Wrapper.m_DepthControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDepthControlActions instance)
        {
            foreach (var item in m_Wrapper.m_DepthControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DepthControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DepthControlActions @DepthControl => new DepthControlActions(this);
    public interface IVerticalControlActions
    {
        void OnUpAndDown(InputAction.CallbackContext context);
    }
    public interface IHorizontalControlActions
    {
        void OnRightAndLeft(InputAction.CallbackContext context);
    }
    public interface IDepthControlActions
    {
        void OnBackAndFoward(InputAction.CallbackContext context);
    }
}

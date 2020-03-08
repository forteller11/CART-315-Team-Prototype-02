// GENERATED AUTOMATICALLY FROM 'Assets/ControlsMain.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControlsMain : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlsMain()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlsMain"",
    ""maps"": [
        {
            ""name"": ""Hand"",
            ""id"": ""4d014b15-3e93-4112-8a07-0a726c899aa0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c82f1606-de31-4f5a-8702-3db3789d909a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""dd63a338-e021-4420-9cd3-1ab203cc50e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed159a76-f340-479b-86cc-5dd96587f878"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a506177f-04fc-4c36-9741-9bcb0b092982"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a225adad-308d-478b-98ea-723ab023ec4a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f683d73-8d11-4f1b-9fe7-df88a0c9f7f6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hand
        m_Hand = asset.FindActionMap("Hand", throwIfNotFound: true);
        m_Hand_Move = m_Hand.FindAction("Move", throwIfNotFound: true);
        m_Hand_Grab = m_Hand.FindAction("Grab", throwIfNotFound: true);
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

    // Hand
    private readonly InputActionMap m_Hand;
    private IHandActions m_HandActionsCallbackInterface;
    private readonly InputAction m_Hand_Move;
    private readonly InputAction m_Hand_Grab;
    public struct HandActions
    {
        private @ControlsMain m_Wrapper;
        public HandActions(@ControlsMain wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Hand_Move;
        public InputAction @Grab => m_Wrapper.m_Hand_Grab;
        public InputActionMap Get() { return m_Wrapper.m_Hand; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HandActions set) { return set.Get(); }
        public void SetCallbacks(IHandActions instance)
        {
            if (m_Wrapper.m_HandActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_HandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnMove;
                @Grab.started -= m_Wrapper.m_HandActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_HandActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_HandActionsCallbackInterface.OnGrab;
            }
            m_Wrapper.m_HandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
            }
        }
    }
    public HandActions @Hand => new HandActions(this);
    public interface IHandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/Input/CustomInput.inputactions
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

public partial class @CustomInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CustomInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CustomInput"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""2d82b5b7-3dff-47d5-ac0a-e680d75e4ed0"",
            ""actions"": [
                {
                    ""name"": ""punch"",
                    ""type"": ""Button"",
                    ""id"": ""90ee9074-19dd-4ecf-8a53-828c9131de2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""getter"",
                    ""type"": ""Button"",
                    ""id"": ""60b2a8e1-e42e-41a3-b1ff-0f292a625e12"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""15524b04-1798-4573-89ab-612c2859b73a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""312d100c-12b7-4801-b74e-9de675c8c958"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button4"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3158b19-cb14-48e6-b7b6-9cd30914e3d8"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button3"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""getter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a3b2ab6f-08d3-452c-8bea-ddf6398fbc5f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""091a7e2b-9d6c-4dab-9ab9-f692615cc8d7"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d7ec612f-b024-488f-b82f-7c615c4ea296"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a1a45f5f-c99f-4464-a4cb-c7032bc6d84f"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_punch = m_player.FindAction("punch", throwIfNotFound: true);
        m_player_getter = m_player.FindAction("getter", throwIfNotFound: true);
        m_player_move = m_player.FindAction("move", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_player_punch;
    private readonly InputAction m_player_getter;
    private readonly InputAction m_player_move;
    public struct PlayerActions
    {
        private @CustomInput m_Wrapper;
        public PlayerActions(@CustomInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @punch => m_Wrapper.m_player_punch;
        public InputAction @getter => m_Wrapper.m_player_getter;
        public InputAction @move => m_Wrapper.m_player_move;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @punch.started += instance.OnPunch;
            @punch.performed += instance.OnPunch;
            @punch.canceled += instance.OnPunch;
            @getter.started += instance.OnGetter;
            @getter.performed += instance.OnGetter;
            @getter.canceled += instance.OnGetter;
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @punch.started -= instance.OnPunch;
            @punch.performed -= instance.OnPunch;
            @punch.canceled -= instance.OnPunch;
            @getter.started -= instance.OnGetter;
            @getter.performed -= instance.OnGetter;
            @getter.canceled -= instance.OnGetter;
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPunch(InputAction.CallbackContext context);
        void OnGetter(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}

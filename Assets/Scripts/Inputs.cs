//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs.inputactions
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

public partial class @Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Penguin"",
            ""id"": ""db551097-c491-40dc-820e-ef7a8710d765"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4a6a1d11-cd61-45c3-aa64-ba5533d8a9e8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zipla"",
                    ""type"": ""Button"",
                    ""id"": ""15fcac95-6c2e-4f20-b519-a3088ac979ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9405da9e-39c9-4e4c-ba2a-6698e01d7791"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""2d50f87b-1c49-47c6-bf09-167f0dcb33f2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""ad3ad2ae-e344-48ed-9bf8-aaf67d7b92b3"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""de9a550c-4a3e-4753-8724-c35a10208c27"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4347158b-c294-4184-b049-f4b4afcc68e2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a3fb695-2232-4e8a-bd13-68d121b3d10f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9587b138-b615-4599-b275-00534c6cf192"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zipla"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c65566c-fee9-4fb2-acda-0170e28d5303"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zipla"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Penguin
        m_Penguin = asset.FindActionMap("Penguin", throwIfNotFound: true);
        m_Penguin_Move = m_Penguin.FindAction("Move", throwIfNotFound: true);
        m_Penguin_Zipla = m_Penguin.FindAction("Zipla", throwIfNotFound: true);
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

    // Penguin
    private readonly InputActionMap m_Penguin;
    private List<IPenguinActions> m_PenguinActionsCallbackInterfaces = new List<IPenguinActions>();
    private readonly InputAction m_Penguin_Move;
    private readonly InputAction m_Penguin_Zipla;
    public struct PenguinActions
    {
        private @Inputs m_Wrapper;
        public PenguinActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Penguin_Move;
        public InputAction @Zipla => m_Wrapper.m_Penguin_Zipla;
        public InputActionMap Get() { return m_Wrapper.m_Penguin; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PenguinActions set) { return set.Get(); }
        public void AddCallbacks(IPenguinActions instance)
        {
            if (instance == null || m_Wrapper.m_PenguinActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PenguinActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Zipla.started += instance.OnZipla;
            @Zipla.performed += instance.OnZipla;
            @Zipla.canceled += instance.OnZipla;
        }

        private void UnregisterCallbacks(IPenguinActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Zipla.started -= instance.OnZipla;
            @Zipla.performed -= instance.OnZipla;
            @Zipla.canceled -= instance.OnZipla;
        }

        public void RemoveCallbacks(IPenguinActions instance)
        {
            if (m_Wrapper.m_PenguinActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPenguinActions instance)
        {
            foreach (var item in m_Wrapper.m_PenguinActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PenguinActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PenguinActions @Penguin => new PenguinActions(this);
    public interface IPenguinActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnZipla(InputAction.CallbackContext context);
    }
}
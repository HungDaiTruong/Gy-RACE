//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""89b7205f-03f2-45e9-96b1-9d7cf0b7bf74"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5a489e9b-0d66-4895-a3b5-7ad76089eba2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Turbo"",
                    ""type"": ""Button"",
                    ""id"": ""d632501d-e0d2-4499-9a59-87f627a15872"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""80ed1ae6-f976-4555-8290-58f5931feccf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item"",
                    ""type"": ""Button"",
                    ""id"": ""814aee07-3d2b-44ef-91f6-5cc3a517c51b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Button"",
                    ""id"": ""d68f90d9-e961-46e1-b322-8339bf8beb8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e5bef87b-31a6-468c-ac9f-d1c1a6b5c495"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""65f69136-e90c-4536-ac9a-ec30223134d2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a61f9844-83d0-4b14-ad9f-7c5d701c5974"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ac0083a2-e257-4116-a207-980cce36a827"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49f19bad-f19b-4fe4-8908-ec95e1b77f68"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d19e0e3c-3daf-4709-81ed-742199bf2417"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turbo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7ad657a-e79a-47d9-8b4c-0f9ee8741e9f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac10bac9-0c26-430f-8978-a3f238788017"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4146d82-500c-4794-b39f-a82e9dc63807"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""b6c6495d-6045-42f6-9226-e9e4081ecb15"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""74757af1-d6a9-410b-bc25-9dd3e2a99ffe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Turbo"",
                    ""type"": ""Button"",
                    ""id"": ""2a18e620-03bf-45be-b348-beae36115309"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""Button"",
                    ""id"": ""bbaceb05-402f-4c4a-a5df-c5e9943ebcd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Item"",
                    ""type"": ""Button"",
                    ""id"": ""a05c90d0-8bc0-4836-9811-44bcbb8b8a08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Button"",
                    ""id"": ""0fdf3c75-63e9-4529-a030-fb32e9fd8b8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ARROWS"",
                    ""id"": ""ba44fdcb-1a89-4bfe-8e11-7204cd72209d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""722d28bd-eb60-43d3-b3a8-7251c818aa50"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b9bc6f1c-56b5-4f85-823f-fc2ec0c4b3fd"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2a47e22c-241a-441f-b122-8c6f4cfc765c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""98832afc-44b5-47ea-8f4e-0c274c38be9c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6b88c65c-7bb0-4977-b757-4795b38e616d"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turbo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""361a37a3-abc3-4dda-b0b2-571270b18c40"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c88f85d-52d7-48cd-bbf3-fa7508272e5d"",
                    ""path"": ""<Keyboard>/numpadPeriod"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1ef2237-c347-40ad-a25f-0b5aa3e7cfc3"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""ea6c4d45-d598-4c2b-9096-d47c5bc965f0"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6e3e2a89-1a13-41ef-b72b-786e0d36bfac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skip1"",
                    ""type"": ""Button"",
                    ""id"": ""868e291f-bf98-4926-9554-92ec905c2f29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skip2"",
                    ""type"": ""Button"",
                    ""id"": ""f05c25ba-01a9-4c65-8523-5f04d3d32c71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0a283553-2b28-409e-bad5-ed2c497cc09b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13f1e998-1dc9-4db3-870e-4bef45696240"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce116a27-57c4-45ab-9c5f-8c36192f0313"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39a88379-b3ad-4fef-b8fc-aa8c5aba6321"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skip2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Turbo = m_Player.FindAction("Turbo", throwIfNotFound: true);
        m_Player_Drift = m_Player.FindAction("Drift", throwIfNotFound: true);
        m_Player_Item = m_Player.FindAction("Item", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_Movement = m_Player2.FindAction("Movement", throwIfNotFound: true);
        m_Player2_Turbo = m_Player2.FindAction("Turbo", throwIfNotFound: true);
        m_Player2_Drift = m_Player2.FindAction("Drift", throwIfNotFound: true);
        m_Player2_Item = m_Player2.FindAction("Item", throwIfNotFound: true);
        m_Player2_Camera = m_Player2.FindAction("Camera", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
        m_UI_Skip1 = m_UI.FindAction("Skip1", throwIfNotFound: true);
        m_UI_Skip2 = m_UI.FindAction("Skip2", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Turbo;
    private readonly InputAction m_Player_Drift;
    private readonly InputAction m_Player_Item;
    private readonly InputAction m_Player_Camera;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Turbo => m_Wrapper.m_Player_Turbo;
        public InputAction @Drift => m_Wrapper.m_Player_Drift;
        public InputAction @Item => m_Wrapper.m_Player_Item;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Turbo.started += instance.OnTurbo;
            @Turbo.performed += instance.OnTurbo;
            @Turbo.canceled += instance.OnTurbo;
            @Drift.started += instance.OnDrift;
            @Drift.performed += instance.OnDrift;
            @Drift.canceled += instance.OnDrift;
            @Item.started += instance.OnItem;
            @Item.performed += instance.OnItem;
            @Item.canceled += instance.OnItem;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Turbo.started -= instance.OnTurbo;
            @Turbo.performed -= instance.OnTurbo;
            @Turbo.canceled -= instance.OnTurbo;
            @Drift.started -= instance.OnDrift;
            @Drift.performed -= instance.OnDrift;
            @Drift.canceled -= instance.OnDrift;
            @Item.started -= instance.OnItem;
            @Item.performed -= instance.OnItem;
            @Item.canceled -= instance.OnItem;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
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
    public PlayerActions @Player => new PlayerActions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private List<IPlayer2Actions> m_Player2ActionsCallbackInterfaces = new List<IPlayer2Actions>();
    private readonly InputAction m_Player2_Movement;
    private readonly InputAction m_Player2_Turbo;
    private readonly InputAction m_Player2_Drift;
    private readonly InputAction m_Player2_Item;
    private readonly InputAction m_Player2_Camera;
    public struct Player2Actions
    {
        private @PlayerControls m_Wrapper;
        public Player2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player2_Movement;
        public InputAction @Turbo => m_Wrapper.m_Player2_Turbo;
        public InputAction @Drift => m_Wrapper.m_Player2_Drift;
        public InputAction @Item => m_Wrapper.m_Player2_Item;
        public InputAction @Camera => m_Wrapper.m_Player2_Camera;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void AddCallbacks(IPlayer2Actions instance)
        {
            if (instance == null || m_Wrapper.m_Player2ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Turbo.started += instance.OnTurbo;
            @Turbo.performed += instance.OnTurbo;
            @Turbo.canceled += instance.OnTurbo;
            @Drift.started += instance.OnDrift;
            @Drift.performed += instance.OnDrift;
            @Drift.canceled += instance.OnDrift;
            @Item.started += instance.OnItem;
            @Item.performed += instance.OnItem;
            @Item.canceled += instance.OnItem;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
        }

        private void UnregisterCallbacks(IPlayer2Actions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Turbo.started -= instance.OnTurbo;
            @Turbo.performed -= instance.OnTurbo;
            @Turbo.canceled -= instance.OnTurbo;
            @Drift.started -= instance.OnDrift;
            @Drift.performed -= instance.OnDrift;
            @Drift.canceled -= instance.OnDrift;
            @Item.started -= instance.OnItem;
            @Item.performed -= instance.OnItem;
            @Item.canceled -= instance.OnItem;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
        }

        public void RemoveCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer2Actions instance)
        {
            foreach (var item in m_Wrapper.m_Player2ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player2ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Pause;
    private readonly InputAction m_UI_Skip1;
    private readonly InputAction m_UI_Skip2;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_UI_Pause;
        public InputAction @Skip1 => m_Wrapper.m_UI_Skip1;
        public InputAction @Skip2 => m_Wrapper.m_UI_Skip2;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Skip1.started += instance.OnSkip1;
            @Skip1.performed += instance.OnSkip1;
            @Skip1.canceled += instance.OnSkip1;
            @Skip2.started += instance.OnSkip2;
            @Skip2.performed += instance.OnSkip2;
            @Skip2.canceled += instance.OnSkip2;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Skip1.started -= instance.OnSkip1;
            @Skip1.performed -= instance.OnSkip1;
            @Skip1.canceled -= instance.OnSkip1;
            @Skip2.started -= instance.OnSkip2;
            @Skip2.performed -= instance.OnSkip2;
            @Skip2.canceled -= instance.OnSkip2;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTurbo(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnItem(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnTurbo(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnItem(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnSkip1(InputAction.CallbackContext context);
        void OnSkip2(InputAction.CallbackContext context);
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMageControls"",
            ""id"": ""d5290419-8961-412b-b556-578c751ffe38"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""d213dac1-e492-4e04-ae8a-3bf8f28dd019"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""4909ab55-4ad5-497c-8ee1-5bebe175324b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera Control"",
                    ""type"": ""Button"",
                    ""id"": ""333e22da-5255-4931-9650-a16776931515"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick Cast"",
                    ""type"": ""Button"",
                    ""id"": ""dfd0b8c7-43fa-4a5c-8272-53f9713accd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hard Cast"",
                    ""type"": ""Button"",
                    ""id"": ""96a51e51-56ad-4db2-a7ae-5d19f7ff712d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4b42ca69-e739-408e-a547-98df7cff4615"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StartButton"",
                    ""type"": ""Button"",
                    ""id"": ""c2845beb-e8b5-4ef0-8178-898d5c765126"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn Player"",
                    ""type"": ""Button"",
                    ""id"": ""10cc7ffc-1dd2-4e0b-895f-273761f00822"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Respawn Books"",
                    ""type"": ""Button"",
                    ""id"": ""4dd72b3b-585b-46b1-8038-d5b85fc740e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7b2ed600-0be9-48fb-a65a-6c354e5769a6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8217e4ad-1f27-4f9e-bf41-573b4a56a049"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""77e46e6e-75c5-4d7d-bb84-4b5db58013df"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4117f0b9-59ec-4b6c-bf06-74bc9f27e9d0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a4528353-c511-401f-abef-0ac4e3346a07"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""12d20392-b738-48ce-ad4b-02c75e86e1bf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92038a53-3d50-47b3-ac65-63e983cb1c81"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00fa998a-6167-4e88-bae4-7cc25479b02b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e4bc3f23-cd10-4c49-ac61-dfd14b85bf87"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b8423dd1-b297-446b-bc7e-f97f8822e478"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bb9734a1-4745-4aab-8b60-f194fc79f489"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ada9bc94-daa1-4f2b-b0f6-786806669800"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4a923eb9-d792-45a9-850f-2337c28fbade"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e6914241-33c2-4606-bfc0-60f2486899ef"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Camera Control"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1e8ea0a-c5d9-47e1-8284-87737bf9469b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Quick Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""281ae335-9838-4f40-b988-7766a4db73a1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Quick Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ba7ac36-840b-4b7e-80fe-12ebda074b38"",
                    ""path"": ""<Keyboard>/F"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Hard Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d022b42e-98fe-4265-8ca9-b5594caf58e7"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Hard Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7eb532e6-3f5d-47a9-b90b-88bd35d63774"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bcc8288-891e-4ab6-9b35-b76d7755c341"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62124574-b2aa-4f71-9559-cf1c856d440a"",
                    ""path"": ""<Keyboard>/Escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70ddbdeb-b798-4e05-a9e2-bdbea4add19b"",
                    ""path"": ""<Gamepad>/Start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StartButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4926d479-2111-46c8-9b2e-234d3f44b734"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Respawn Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0586734f-effe-436d-82b6-a8e553617a20"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a177c125-2fdc-4313-9be4-6102ed18a44d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Respawn Books"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cbacbde-c3ba-4312-969b-0a7e7aa375f3"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Respawn Books"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMageControls
        m_PlayerMageControls = asset.FindActionMap("PlayerMageControls", throwIfNotFound: true);
        m_PlayerMageControls_Movement = m_PlayerMageControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMageControls_Throw = m_PlayerMageControls.FindAction("Throw", throwIfNotFound: true);
        m_PlayerMageControls_CameraControl = m_PlayerMageControls.FindAction("Camera Control", throwIfNotFound: true);
        m_PlayerMageControls_QuickCast = m_PlayerMageControls.FindAction("Quick Cast", throwIfNotFound: true);
        m_PlayerMageControls_HardCast = m_PlayerMageControls.FindAction("Hard Cast", throwIfNotFound: true);
        m_PlayerMageControls_Interact = m_PlayerMageControls.FindAction("Interact", throwIfNotFound: true);
        m_PlayerMageControls_StartButton = m_PlayerMageControls.FindAction("StartButton", throwIfNotFound: true);
        m_PlayerMageControls_RespawnPlayer = m_PlayerMageControls.FindAction("Respawn Player", throwIfNotFound: true);
        m_PlayerMageControls_RespawnBooks = m_PlayerMageControls.FindAction("Respawn Books", throwIfNotFound: true);
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

    // PlayerMageControls
    private readonly InputActionMap m_PlayerMageControls;
    private IPlayerMageControlsActions m_PlayerMageControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerMageControls_Movement;
    private readonly InputAction m_PlayerMageControls_Throw;
    private readonly InputAction m_PlayerMageControls_CameraControl;
    private readonly InputAction m_PlayerMageControls_QuickCast;
    private readonly InputAction m_PlayerMageControls_HardCast;
    private readonly InputAction m_PlayerMageControls_Interact;
    private readonly InputAction m_PlayerMageControls_StartButton;
    private readonly InputAction m_PlayerMageControls_RespawnPlayer;
    private readonly InputAction m_PlayerMageControls_RespawnBooks;
    public struct PlayerMageControlsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMageControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMageControls_Movement;
        public InputAction @Throw => m_Wrapper.m_PlayerMageControls_Throw;
        public InputAction @CameraControl => m_Wrapper.m_PlayerMageControls_CameraControl;
        public InputAction @QuickCast => m_Wrapper.m_PlayerMageControls_QuickCast;
        public InputAction @HardCast => m_Wrapper.m_PlayerMageControls_HardCast;
        public InputAction @Interact => m_Wrapper.m_PlayerMageControls_Interact;
        public InputAction @StartButton => m_Wrapper.m_PlayerMageControls_StartButton;
        public InputAction @RespawnPlayer => m_Wrapper.m_PlayerMageControls_RespawnPlayer;
        public InputAction @RespawnBooks => m_Wrapper.m_PlayerMageControls_RespawnBooks;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMageControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMageControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMageControlsActions instance)
        {
            if (m_Wrapper.m_PlayerMageControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnMovement;
                @Throw.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnThrow;
                @CameraControl.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnCameraControl;
                @CameraControl.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnCameraControl;
                @CameraControl.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnCameraControl;
                @QuickCast.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnQuickCast;
                @QuickCast.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnQuickCast;
                @QuickCast.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnQuickCast;
                @HardCast.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnHardCast;
                @HardCast.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnHardCast;
                @HardCast.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnHardCast;
                @Interact.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnInteract;
                @StartButton.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnStartButton;
                @StartButton.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnStartButton;
                @StartButton.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnStartButton;
                @RespawnPlayer.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnRespawnPlayer;
                @RespawnPlayer.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnRespawnPlayer;
                @RespawnPlayer.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnRespawnPlayer;
                @RespawnBooks.started -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnRespawnBooks;
                @RespawnBooks.performed -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnRespawnBooks;
                @RespawnBooks.canceled -= m_Wrapper.m_PlayerMageControlsActionsCallbackInterface.OnRespawnBooks;
            }
            m_Wrapper.m_PlayerMageControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @CameraControl.started += instance.OnCameraControl;
                @CameraControl.performed += instance.OnCameraControl;
                @CameraControl.canceled += instance.OnCameraControl;
                @QuickCast.started += instance.OnQuickCast;
                @QuickCast.performed += instance.OnQuickCast;
                @QuickCast.canceled += instance.OnQuickCast;
                @HardCast.started += instance.OnHardCast;
                @HardCast.performed += instance.OnHardCast;
                @HardCast.canceled += instance.OnHardCast;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @StartButton.started += instance.OnStartButton;
                @StartButton.performed += instance.OnStartButton;
                @StartButton.canceled += instance.OnStartButton;
                @RespawnPlayer.started += instance.OnRespawnPlayer;
                @RespawnPlayer.performed += instance.OnRespawnPlayer;
                @RespawnPlayer.canceled += instance.OnRespawnPlayer;
                @RespawnBooks.started += instance.OnRespawnBooks;
                @RespawnBooks.performed += instance.OnRespawnBooks;
                @RespawnBooks.canceled += instance.OnRespawnBooks;
            }
        }
    }
    public PlayerMageControlsActions @PlayerMageControls => new PlayerMageControlsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerMageControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnCameraControl(InputAction.CallbackContext context);
        void OnQuickCast(InputAction.CallbackContext context);
        void OnHardCast(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnStartButton(InputAction.CallbackContext context);
        void OnRespawnPlayer(InputAction.CallbackContext context);
        void OnRespawnBooks(InputAction.CallbackContext context);
    }
}

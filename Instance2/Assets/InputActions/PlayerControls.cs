//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputActions/PlayerControls.inputactions
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
            ""name"": ""PlayerInput"",
            ""id"": ""8dcc778f-9478-4cdb-b6e7-5a1f49c10fcf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""786a3f7f-954e-481a-9ed8-5429ddd584b0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=5)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Inventary"",
                    ""type"": ""Value"",
                    ""id"": ""1d967906-59e7-4efc-a3c0-8f3ee1bf9dd7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=5)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraZoomIn"",
                    ""type"": ""Button"",
                    ""id"": ""593b79e9-d360-40af-924c-1525f352c0f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraZoomOut"",
                    ""type"": ""Button"",
                    ""id"": ""6fca6358-d7b8-452c-aec7-c1c23d679721"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraMove"",
                    ""type"": ""Value"",
                    ""id"": ""d073b033-2376-4b7e-aea1-3269c59e61c2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""EndTurn"",
                    ""type"": ""Button"",
                    ""id"": ""3d4e042d-1060-48a4-a788-520700352882"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchMap"",
                    ""type"": ""Button"",
                    ""id"": ""8aea4fdf-d623-4ec7-805e-04559ab8a1f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OpenGrave"",
                    ""type"": ""Button"",
                    ""id"": ""c25e2272-1767-4816-81fa-ecf7c9a8195e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""c26ddd25-f536-4237-aeb5-3bad152f767a"",
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
                    ""id"": ""452a17c6-c46f-4f4a-b6a0-4beb2463defd"",
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
                    ""id"": ""e21b8ddb-b650-408c-86c8-0383dc02f441"",
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
                    ""id"": ""1176361d-ddef-43ef-9024-47b1417dffe8"",
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
                    ""id"": ""ffd11fc6-6213-42dc-a5ce-6f6bbb8fda88"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""17dffb4b-7361-4aff-8dae-e6781e66d048"",
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
                    ""id"": ""e9d40759-cd6e-452f-abe5-0490e6f923b8"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ca6fdaa3-108c-410c-8468-486db0f0a21f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1561a728-8e00-4d9c-a92e-5f727caee37c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""17655602-f312-4c45-a55c-cca17717272f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""8ccd43d3-b993-4e3b-bfc6-0e973a3cb1cd"",
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
                    ""id"": ""43c2bbb8-aaad-4299-8fde-dae235c48e7e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e0c9f9b5-5398-400c-9bde-a278181231b8"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""24f52ace-963a-43d8-9f9f-b5f5aa3097ca"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ac8ce41b-be15-441d-8ded-c028f81b779f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""joystick"",
                    ""id"": ""c8181658-bd45-4777-841c-92c656726bdf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventary"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b325521d-e5c2-40ab-8d29-11fa3e415616"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d35e70d1-0cc6-4dde-a652-2f71cc29c877"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5cd2f373-4b63-49bd-892b-7ae4a13c45d0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""660fde4b-88c8-4d53-9084-6aff39fb7627"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5255759c-78ea-4cd1-8371-da131fb83d94"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoomIn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5a68d4a-7823-43d4-89b9-297bfe716c0a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoomOut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c6cd9b6e-2489-414c-88f5-2f0c692722ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""33183f5d-07e2-4dc5-9a5b-b7b2e119f01e"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82ca6450-27e2-4ee8-8d5e-75e8c8b90be8"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4b97a794-5375-460c-b87f-325e92bdf496"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""516b8820-a391-4a9e-86c9-1e6f9e09905c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""67831def-76a2-4fc9-b9c5-8a34dee126b0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EndTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4288823-a7ff-4132-962e-2f3001b29a2a"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fa3c5c9a-1030-4a4f-a44a-c1a653d9ddd1"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenGrave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SelectArtefact"",
            ""id"": ""07c23649-2f0d-4355-bb56-22573ae8d00a"",
            ""actions"": [
                {
                    ""name"": ""Navigation"",
                    ""type"": ""Value"",
                    ""id"": ""093c250c-9cc5-438c-bb67-6b92826ca7fe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectAtifact"",
                    ""type"": ""Button"",
                    ""id"": ""e610867a-4624-4cb5-a8fc-aece654521cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel Selection"",
                    ""type"": ""Button"",
                    ""id"": ""84ee6177-db20-4cc4-b2d5-ed9d621fbd13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DestroyCard"",
                    ""type"": ""Button"",
                    ""id"": ""cd98af00-18dd-45f6-ac61-10b8e629ca6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""KeepArtifact"",
                    ""type"": ""Button"",
                    ""id"": ""0d29796b-f1ff-40bb-aaed-53a215a0eeb1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""131e3b27-3f24-4f65-8d4d-16af854a67b1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f652d8cb-a699-45de-abb3-8a9bda7743ec"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""345c52ed-9945-4df9-8cba-c2b44f12a2de"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""98f3a93e-dc23-421b-8d5f-00368e9cff73"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bd2b3366-e1d7-4486-b9ec-e96a7a2db502"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9d17665a-0350-4bb9-8f96-7e48ab256e53"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectAtifact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""332315a1-c5eb-4b14-8f89-e1d6e25649e3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79ed914d-868f-4b51-a1c0-7dcd9d23958e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DestroyCard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d20837e-1960-4f73-8a44-231112619820"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""KeepArtifact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Movement = m_PlayerInput.FindAction("Movement", throwIfNotFound: true);
        m_PlayerInput_Inventary = m_PlayerInput.FindAction("Inventary", throwIfNotFound: true);
        m_PlayerInput_CameraZoomIn = m_PlayerInput.FindAction("CameraZoomIn", throwIfNotFound: true);
        m_PlayerInput_CameraZoomOut = m_PlayerInput.FindAction("CameraZoomOut", throwIfNotFound: true);
        m_PlayerInput_CameraMove = m_PlayerInput.FindAction("CameraMove", throwIfNotFound: true);
        m_PlayerInput_EndTurn = m_PlayerInput.FindAction("EndTurn", throwIfNotFound: true);
        m_PlayerInput_SwitchMap = m_PlayerInput.FindAction("SwitchMap", throwIfNotFound: true);
        m_PlayerInput_OpenGrave = m_PlayerInput.FindAction("OpenGrave", throwIfNotFound: true);
        // SelectArtefact
        m_SelectArtefact = asset.FindActionMap("SelectArtefact", throwIfNotFound: true);
        m_SelectArtefact_Navigation = m_SelectArtefact.FindAction("Navigation", throwIfNotFound: true);
        m_SelectArtefact_SelectAtifact = m_SelectArtefact.FindAction("SelectAtifact", throwIfNotFound: true);
        m_SelectArtefact_CancelSelection = m_SelectArtefact.FindAction("Cancel Selection", throwIfNotFound: true);
        m_SelectArtefact_DestroyCard = m_SelectArtefact.FindAction("DestroyCard", throwIfNotFound: true);
        m_SelectArtefact_KeepArtifact = m_SelectArtefact.FindAction("KeepArtifact", throwIfNotFound: true);
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

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private List<IPlayerInputActions> m_PlayerInputActionsCallbackInterfaces = new List<IPlayerInputActions>();
    private readonly InputAction m_PlayerInput_Movement;
    private readonly InputAction m_PlayerInput_Inventary;
    private readonly InputAction m_PlayerInput_CameraZoomIn;
    private readonly InputAction m_PlayerInput_CameraZoomOut;
    private readonly InputAction m_PlayerInput_CameraMove;
    private readonly InputAction m_PlayerInput_EndTurn;
    private readonly InputAction m_PlayerInput_SwitchMap;
    private readonly InputAction m_PlayerInput_OpenGrave;
    public struct PlayerInputActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerInputActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerInput_Movement;
        public InputAction @Inventary => m_Wrapper.m_PlayerInput_Inventary;
        public InputAction @CameraZoomIn => m_Wrapper.m_PlayerInput_CameraZoomIn;
        public InputAction @CameraZoomOut => m_Wrapper.m_PlayerInput_CameraZoomOut;
        public InputAction @CameraMove => m_Wrapper.m_PlayerInput_CameraMove;
        public InputAction @EndTurn => m_Wrapper.m_PlayerInput_EndTurn;
        public InputAction @SwitchMap => m_Wrapper.m_PlayerInput_SwitchMap;
        public InputAction @OpenGrave => m_Wrapper.m_PlayerInput_OpenGrave;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerInputActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Inventary.started += instance.OnInventary;
            @Inventary.performed += instance.OnInventary;
            @Inventary.canceled += instance.OnInventary;
            @CameraZoomIn.started += instance.OnCameraZoomIn;
            @CameraZoomIn.performed += instance.OnCameraZoomIn;
            @CameraZoomIn.canceled += instance.OnCameraZoomIn;
            @CameraZoomOut.started += instance.OnCameraZoomOut;
            @CameraZoomOut.performed += instance.OnCameraZoomOut;
            @CameraZoomOut.canceled += instance.OnCameraZoomOut;
            @CameraMove.started += instance.OnCameraMove;
            @CameraMove.performed += instance.OnCameraMove;
            @CameraMove.canceled += instance.OnCameraMove;
            @EndTurn.started += instance.OnEndTurn;
            @EndTurn.performed += instance.OnEndTurn;
            @EndTurn.canceled += instance.OnEndTurn;
            @SwitchMap.started += instance.OnSwitchMap;
            @SwitchMap.performed += instance.OnSwitchMap;
            @SwitchMap.canceled += instance.OnSwitchMap;
            @OpenGrave.started += instance.OnOpenGrave;
            @OpenGrave.performed += instance.OnOpenGrave;
            @OpenGrave.canceled += instance.OnOpenGrave;
        }

        private void UnregisterCallbacks(IPlayerInputActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Inventary.started -= instance.OnInventary;
            @Inventary.performed -= instance.OnInventary;
            @Inventary.canceled -= instance.OnInventary;
            @CameraZoomIn.started -= instance.OnCameraZoomIn;
            @CameraZoomIn.performed -= instance.OnCameraZoomIn;
            @CameraZoomIn.canceled -= instance.OnCameraZoomIn;
            @CameraZoomOut.started -= instance.OnCameraZoomOut;
            @CameraZoomOut.performed -= instance.OnCameraZoomOut;
            @CameraZoomOut.canceled -= instance.OnCameraZoomOut;
            @CameraMove.started -= instance.OnCameraMove;
            @CameraMove.performed -= instance.OnCameraMove;
            @CameraMove.canceled -= instance.OnCameraMove;
            @EndTurn.started -= instance.OnEndTurn;
            @EndTurn.performed -= instance.OnEndTurn;
            @EndTurn.canceled -= instance.OnEndTurn;
            @SwitchMap.started -= instance.OnSwitchMap;
            @SwitchMap.performed -= instance.OnSwitchMap;
            @SwitchMap.canceled -= instance.OnSwitchMap;
            @OpenGrave.started -= instance.OnOpenGrave;
            @OpenGrave.performed -= instance.OnOpenGrave;
            @OpenGrave.canceled -= instance.OnOpenGrave;
        }

        public void RemoveCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerInputActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);

    // SelectArtefact
    private readonly InputActionMap m_SelectArtefact;
    private List<ISelectArtefactActions> m_SelectArtefactActionsCallbackInterfaces = new List<ISelectArtefactActions>();
    private readonly InputAction m_SelectArtefact_Navigation;
    private readonly InputAction m_SelectArtefact_SelectAtifact;
    private readonly InputAction m_SelectArtefact_CancelSelection;
    private readonly InputAction m_SelectArtefact_DestroyCard;
    private readonly InputAction m_SelectArtefact_KeepArtifact;
    public struct SelectArtefactActions
    {
        private @PlayerControls m_Wrapper;
        public SelectArtefactActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigation => m_Wrapper.m_SelectArtefact_Navigation;
        public InputAction @SelectAtifact => m_Wrapper.m_SelectArtefact_SelectAtifact;
        public InputAction @CancelSelection => m_Wrapper.m_SelectArtefact_CancelSelection;
        public InputAction @DestroyCard => m_Wrapper.m_SelectArtefact_DestroyCard;
        public InputAction @KeepArtifact => m_Wrapper.m_SelectArtefact_KeepArtifact;
        public InputActionMap Get() { return m_Wrapper.m_SelectArtefact; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectArtefactActions set) { return set.Get(); }
        public void AddCallbacks(ISelectArtefactActions instance)
        {
            if (instance == null || m_Wrapper.m_SelectArtefactActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SelectArtefactActionsCallbackInterfaces.Add(instance);
            @Navigation.started += instance.OnNavigation;
            @Navigation.performed += instance.OnNavigation;
            @Navigation.canceled += instance.OnNavigation;
            @SelectAtifact.started += instance.OnSelectAtifact;
            @SelectAtifact.performed += instance.OnSelectAtifact;
            @SelectAtifact.canceled += instance.OnSelectAtifact;
            @CancelSelection.started += instance.OnCancelSelection;
            @CancelSelection.performed += instance.OnCancelSelection;
            @CancelSelection.canceled += instance.OnCancelSelection;
            @DestroyCard.started += instance.OnDestroyCard;
            @DestroyCard.performed += instance.OnDestroyCard;
            @DestroyCard.canceled += instance.OnDestroyCard;
            @KeepArtifact.started += instance.OnKeepArtifact;
            @KeepArtifact.performed += instance.OnKeepArtifact;
            @KeepArtifact.canceled += instance.OnKeepArtifact;
        }

        private void UnregisterCallbacks(ISelectArtefactActions instance)
        {
            @Navigation.started -= instance.OnNavigation;
            @Navigation.performed -= instance.OnNavigation;
            @Navigation.canceled -= instance.OnNavigation;
            @SelectAtifact.started -= instance.OnSelectAtifact;
            @SelectAtifact.performed -= instance.OnSelectAtifact;
            @SelectAtifact.canceled -= instance.OnSelectAtifact;
            @CancelSelection.started -= instance.OnCancelSelection;
            @CancelSelection.performed -= instance.OnCancelSelection;
            @CancelSelection.canceled -= instance.OnCancelSelection;
            @DestroyCard.started -= instance.OnDestroyCard;
            @DestroyCard.performed -= instance.OnDestroyCard;
            @DestroyCard.canceled -= instance.OnDestroyCard;
            @KeepArtifact.started -= instance.OnKeepArtifact;
            @KeepArtifact.performed -= instance.OnKeepArtifact;
            @KeepArtifact.canceled -= instance.OnKeepArtifact;
        }

        public void RemoveCallbacks(ISelectArtefactActions instance)
        {
            if (m_Wrapper.m_SelectArtefactActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISelectArtefactActions instance)
        {
            foreach (var item in m_Wrapper.m_SelectArtefactActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SelectArtefactActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SelectArtefactActions @SelectArtefact => new SelectArtefactActions(this);
    public interface IPlayerInputActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInventary(InputAction.CallbackContext context);
        void OnCameraZoomIn(InputAction.CallbackContext context);
        void OnCameraZoomOut(InputAction.CallbackContext context);
        void OnCameraMove(InputAction.CallbackContext context);
        void OnEndTurn(InputAction.CallbackContext context);
        void OnSwitchMap(InputAction.CallbackContext context);
        void OnOpenGrave(InputAction.CallbackContext context);
    }
    public interface ISelectArtefactActions
    {
        void OnNavigation(InputAction.CallbackContext context);
        void OnSelectAtifact(InputAction.CallbackContext context);
        void OnCancelSelection(InputAction.CallbackContext context);
        void OnDestroyCard(InputAction.CallbackContext context);
        void OnKeepArtifact(InputAction.CallbackContext context);
    }
}

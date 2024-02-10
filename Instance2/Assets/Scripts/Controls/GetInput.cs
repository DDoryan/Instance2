using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private CameraControl _camera;
    private Vector2 _position;
    private bool _zoomIn;
    private bool _zoomOut;
    private bool _moveCam;

    private PlayerInput _playerInput;

    private PlayerControls _playerControls;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControls = new PlayerControls();
    }

    private void FixedUpdate()
    {
        if (_zoomIn)
        {
            _camera.ZoomCamera(true);
        }
        else if (_zoomOut)
        {
            _camera.ZoomCamera(false);
        }
        if (_moveCam)
        {
            _camera.MoveCam(_position);
        }
    }

    public void SwitchMap(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _playerInput.actions.FindActionMap("SelectArtefact").Enable();
            _playerInput.actions.FindActionMap("PlayerInput").Disable();
            Debug.Log("SwitchMap");
        }
    }
    public void SwitchMapInverted(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _playerInput.actions.FindActionMap("SelectArtefact").Disable();
            _playerInput.actions.FindActionMap("PlayerInput").Enable();
            Debug.Log("SwitchMap");

        }
    }

    public void ExchangeAction(InputAction.CallbackContext context)
    {
        if (context.performed && (PlayerManager.playerManager.InventoryAmmount(0) > 0 || PlayerManager.playerManager.InventoryAmmount(1) > 0))
        {
            _playerInput.actions.FindActionMap("SelectArtefact").Disable();
            _playerInput.actions.FindActionMap("PlayerInput").Disable();
            _playerInput.actions.FindActionMap("ExchangeSystem").Enable();
            PlayerManager.playerManager.ExchangeStart();
            Debug.Log("Perform");
        }
    }



    public void SelectionEventStart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerManager.playerManager.SelectedArtifact();
        }
    }






    public void ActiveInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerManager.playerManager.ActiveInventory();
        }
    }




    public void OpenGrave(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _playerManager.AddToInventory();
        }
    }

    public void SelectArtifact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerManager.SelectedArtifact();
        }
    }



    public void AcceptArtifact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerManager.KeepArtifact();
        }
    }

    public void DestroyArtifact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerManager.DestroyArtifact();
        }
    }

    public void GetDirectionInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerManager.MovePlayer(context.ReadValue<Vector2>());
        }
    }

    public void GetNavigationInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerManager.NavigateInventory(context.ReadValue<Vector2>());
        }
    }

    public void GetCameraInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _position = context.ReadValue<Vector2>();
            _moveCam = true;
        }
        if (context.canceled)
        {
            _moveCam = false;
        }
    }

    public void GetZoomInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
                _zoomIn = true;
        }
        if (context.canceled)
        {
            _zoomIn = false;
        }
    }

    public void GetZoomOut(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _zoomOut = true;
        }
        if (context.canceled)
        {
            _zoomOut = false;
        }
    }

    public void GetEndTurn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerManager.PassTurn();
        }
    }

    public void GetCastSpell(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerManager.CastSpell();
        }
    }
}

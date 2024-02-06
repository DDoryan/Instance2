using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraControl _camera;

    private bool _zoomIn;
    private bool _zoomOut;

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
    }

    public void GetDirectionInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _player.GetDirections(context.ReadValue<Vector2>());
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
}

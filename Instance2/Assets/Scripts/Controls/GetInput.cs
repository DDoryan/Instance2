using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GetInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraControl _camera;
    private Vector2 _position;
    private bool _zoomIn;
    private bool _zoomOut;
    private bool _moveCam;

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

    public void GetDirectionInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _player.GetDirections(context.ReadValue<Vector2>());
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
        if (context.canceled)
        {
            _player.GetTurnEnd();
        }
    }
}

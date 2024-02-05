using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    public void GetDirectionInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _player.GetDirections(context.ReadValue<Vector2>());
        }
    }
}

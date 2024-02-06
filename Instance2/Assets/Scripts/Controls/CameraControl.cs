using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _sensibility;
    [SerializeField] private Transform _camPos;
    [SerializeField] private Camera _cam;

    public void ZoomCamera(bool value)
    {
        if (!value)
        {
            Zoom(1);
        }
        else
        {
            Zoom(-1);
        }
    }

    private void Zoom(int InOrOut)
    {
        _cam.orthographicSize += ((_maxZoom-_minZoom)*Time.deltaTime) * InOrOut;
    }

    public void MoveCam(Vector2 value)
    {
        _camPos.position += (new Vector3(value.x, value.y, 0) / _sensibility);
    }
}

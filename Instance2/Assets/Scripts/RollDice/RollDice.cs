using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public enum Direction
{
    Left,
    Right,
    Up,
    Down,
}


public class RollDice : MonoBehaviour
{
    private Rigidbody _body;

    [SerializeField] private float _maxRandomForceValue, _rollingForce;
    private float _forceX, _forceY, _forceZ;
    
    public int DiceFaceNum;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (_body != null)
        {
            if (Input.GetMouseButton(0))
            {
                RollingDice();
            }
        }
    }

    private void RollingDice()
    {
        _body.isKinematic = false;        

        _forceX = Random.Range(-_maxRandomForceValue, _maxRandomForceValue);
        _forceY = Random.Range(-_maxRandomForceValue, _maxRandomForceValue);
        _forceZ = Random.Range(-_maxRandomForceValue, _maxRandomForceValue);

        _body.AddForce(Vector3.up * _rollingForce);
        _body.AddTorque(_forceX, _forceY, _forceZ);
    }

    private void Initialize()
    {
        _body = GetComponent<Rigidbody>();
        _body.isKinematic = true;
        transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
    }
}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : Entity
{
    [SerializeField] private int _perkLimit;
    private List<CardBaseGrave> _perkList;
    [SerializeField] private bool _canOpenTombs;
    private int _cellOn;
    private int _selectedPerk;
    private Vector3 _destination;
    private PlayerState _myState;
    [SerializeField] private float _cellSize;
    [SerializeField] private Ressources _ressources;
    [SerializeField] private Transform _playerPos;

    void Start()
    {
        _selectedPerk = 0;
        _perkList = new List<CardBaseGrave>();
        _myState = PlayerState.idle;
    }

    private void FixedUpdate()
    {
        switch ( _myState )
        {
            case PlayerState.moving:
                if (_ressources.SubstractActionPoints(1))
                {
                    _playerPos.position = _destination;
                }
                _myState= PlayerState.idle;
                break;
            default: 
                break;
        }
    }

    public void NavigateAssets(InputAction.CallbackContext context)
    {
        if (_selectedPerk + context.ReadValue<Vector2>().x.ConvertTo<int>() <= _perkList.Count && _selectedPerk + context.ReadValue<Vector2>().x.ConvertTo<int>() >= 1)
        {
            if (!_perkList[_selectedPerk + context.ReadValue<Vector2>().x.ConvertTo<int>()].IsUnityNull())
            {
                _selectedPerk += context.ReadValue<Vector2>().x.ConvertTo<int>();
            }
        }
        return;
    }

    /*public bool HasKey()
    {
        
    }*/

    public void SetCanOpenTomb(bool value)
    {
        _canOpenTombs = value;
    }

    public void SetAssetLimit(int value)
    {
        _perkLimit = value;
    }

    public void GetDirections(Vector2 direction)
    {
        if (_myState == PlayerState.idle) 
        { 
        switch (direction.y)
        {
            case 1:
                _destination = _playerPos.position + Vector3.up * _cellSize;
                break;

            case -1:
                _destination = _playerPos.position + Vector3.down * _cellSize;
                break;
        }

            switch (direction.x)
            {
                case 1:
                    _destination = _playerPos.position + Vector3.right * _cellSize;
                    break;

                case -1:
                    _destination = _playerPos.position + Vector3.left * _cellSize;
                    break;
            }
            _myState = PlayerState.moving;
        }
    }

    /*private void SetDestination()
    {

    }*/
}

public enum PlayerState
{
    idle, moving,
}

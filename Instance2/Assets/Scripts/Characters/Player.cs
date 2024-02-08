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
    [SerializeField] private Transform _playerPos;
    [SerializeField] private List<CardBaseGrave> _inventoryPlayer1 = new List<CardBaseGrave>();
    [SerializeField] private List<CardBaseGrave> _inventoryPlayer2 = new List<CardBaseGrave>();
    [SerializeField] private bool _haveTreasure;
    public List<CardBaseGrave> InventoryPlayer1
    {
        get { return _inventoryPlayer1; }
    }
    public List<CardBaseGrave> InventoryPlayer2
    {
        get { return _inventoryPlayer2; }
    }

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
                if (Ressources.Instance.SubstractActionPoints(1))
                {
                    _playerPos.position = _destination;
                }
                else
                {
                    EndRound();
                }
                _myState= PlayerState.idle;
                break;
            default: 
                break;
        }
    }

    public void NavigateAssets(InputAction.CallbackContext context)
    {
        if (!_isTurn) 
        { 
            return; 
        }
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

    public void GetTurnEnd()
    {
        if (_isTurn)
        {
            EndRound();
            print("endturn");
        }
        return;
    }

    public void GetDirections(Vector2 direction)
    {
        if (_isTurn)
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
    }

    /*private void SetDestination()
    {

    }*/

    public void AddToInventory()
    {
        //_inventoryPlayer1.Add(_grave.Interact());
    }

    public bool GetObject()
    {
        for (int i = 0; i < _inventoryPlayer1.Count; i++)
        {
            if (_inventoryPlayer1[i].CardType == CardType.key)
            {
                _inventoryPlayer1.RemoveAt(i);
                return true;
            }
            else
            {
                Debug.Log("You can't open the graveStone, get a Key");
            }
        }
        return false;
    }

    public void SetBool()
    {
        /*if (_stone.Interact() == false)
        {
            _haveTreasure = false;
            Debug.Log("Sorry Wrong GraveStone");
        }
        else if (_stone.Interact() == true)
        {
            _haveTreasure = true;
            Debug.Log("Get The Treasure");
        }*/
    }
}

public enum PlayerState
{
    idle, moving,
}

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{
    [SerializeField] private int _perkLimit;
    [SerializeField] private bool _canOpenTombs;
    private PlayerManager _playerManager;
    private int _cellOn;
    private int _selectedPerk;
    private Vector3 _destination;
    private PlayerState _myState;
    [SerializeField] private float _cellSize;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private List<BasePerk> _inventoryPlayer = new List<BasePerk>();
    [SerializeField] private bool _haveTreasure;
    public List<BasePerk> InventoryPlayer
    {
        get { return _inventoryPlayer; }
    }

    void Start()
    {
        _selectedPerk = 0;
        _myState = PlayerState.idle;
    }

    private void FixedUpdate()
    {
        switch ( _myState )
        {
            case PlayerState.moving:
                _playerPos.position = _destination;
                _myState= PlayerState.idle;
                break;
            default: 
                break;
        }
    }

    public void NavigatePerks(Vector2 direction)
    {
        if (_selectedPerk + direction.x.ConvertTo<int>() <= _inventoryPlayer.Count && _selectedPerk + direction.x.ConvertTo<int>() >= 1)
        {
            if (!_inventoryPlayer[_selectedPerk + direction.x.ConvertTo<int>()].IsUnityNull())
            {
                _selectedPerk += direction.x.ConvertTo<int>();
            }
        }
        return;
    }

    /*public bool HasKey()
    {
        
    }*/

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

    public void AddToInventory()
    {
        //_inventoryPlayer1.Add(_grave.Interact());
    }

    public bool GetObject()
    {
        for (int i = 0; i < _inventoryPlayer.Count; i++)
        {
            if (_inventoryPlayer[i].CardType == CardType.Key)
            {
                _inventoryPlayer.RemoveAt(i);
                return true;
            }
            else
            {
                Debug.Log("You can't open the graveStone, get a Key");
            }
        }
        return false;
    }

    public int CastSpell(int ressource)
    {
        if (ressource - _inventoryPlayer[_selectedPerk].Cost < 0)
        {
            return 0;
        }
        else
        {
            //_inventoryPlayer[_selectedPerk].Use();
            return _inventoryPlayer[_selectedPerk].Cost;
        }
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

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{





    [SerializeField] private int _perkLimit;
    [SerializeField] private bool _canOpenTombs;

    private bool _artefactFull;

    private PlayerManager _playerManager;
    private int _cellOn;
    private int _selectedPerk;
    private Vector3 _destination;
    private PlayerState _myState;
    [SerializeField] private float _cellSize;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private List<Artefacte> _inventoryPlayer = new List<Artefacte>();
    [SerializeField] private bool _haveTreasure;

    [SerializeField] private Artefacte _artefact;

    private Artefacte _artefactSelection;
    [SerializeField] private Artefacte _artefactSelected;

    [SerializeField] private Grave _grave;
    public List<Artefacte> InventoryPlayer
    {
        get { return _inventoryPlayer; }
    }

    public int SelectedPerk
    {
        get { return _selectedPerk; }
    }

    void Start()
    {
        _selectedPerk = 0;
        _myState = PlayerState.idle;
        //_grave = new Grave(CaseType.Grave, false, false, 1, null, Vector2.zero, null);
    }

    private void FixedUpdate()
    {
        switch (_myState)
        {
            case PlayerState.moving:
                _playerPos.position = _destination;
                _myState = PlayerState.idle;
                break;
            default:
                break;
        }
    }

    public void NavigatePerks(Vector2 direction)
    {
        if (_selectedPerk + direction.x.ConvertTo<int>() < _inventoryPlayer.Count && _selectedPerk + direction.x.ConvertTo<int>() >= 0)
        {
            if (!_inventoryPlayer[_selectedPerk + direction.x.ConvertTo<int>()].IsUnityNull())
            {
                _selectedPerk += direction.x.ConvertTo<int>();
                _artefactSelection = _inventoryPlayer[_selectedPerk];
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

        if (_inventoryPlayer.Count < _perkLimit)
        {
            _inventoryPlayer.Add(_grave.Interact());

        }
        else if (_inventoryPlayer.Count >= _perkLimit && _artefact == null)
        {
            _artefactFull = true;
            _artefact = _grave.Interact();
        }
    }

    public void SelectArtifact()
    {
        _artefactSelected = _artefactSelection;
    }

    public void KeepArtifact()
    {
        if (_artefactFull)
        {
            Deck.GraveDeck.DefaultCard.Add(_artefactSelected);
            _inventoryPlayer.Remove(_artefactSelected);
            _inventoryPlayer.Add(_artefact);
            _artefactSelected = null;
            _artefact = null;
        }
    }

    public void DestroyArtifact()
    {
        if (_artefactFull)
        {
            Deck.GraveDeck.DefaultCard.Add(_artefact);
            _artefact = null;
        }
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
        if (_inventoryPlayer.Count == 0) {  return 0; }
        if (ressource - _inventoryPlayer[_selectedPerk].Cost < 0)
        {
            return 0;
        }
        else
        {
            _inventoryPlayer[_selectedPerk].Use();
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

    public Artefacte GetPerk(int ind)
    {
        if (_inventoryPlayer.Count > ind)
        {
            return _inventoryPlayer[ind];
        }
        else
        {
            return null;
        }
    }

    public int GetSelectedPerk() { return _selectedPerk; }

    public bool IsInventoryEmpty()
    {
        return (_inventoryPlayer.Count == 0);
    }

    public int GetCellOn() { return _cellOn; }

    public int GetPerkLimit() { return _perkLimit; }
}

public enum PlayerState
{
    idle, moving,
}

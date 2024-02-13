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

    private int _cellOn;
    private int _selectedPerk;
    private Vector3 _destination;
    private PlayerState _myState;
    [SerializeField] private Transform _playerPos;
    [SerializeField] private List<Artefacte> _inventoryPlayer = new List<Artefacte>();
    [SerializeField] private bool _haveTreasure;

    [SerializeField] private Artefacte _artefact;

    private Artefacte _artefactYouLook;
    [SerializeField] private Artefacte _artefactSelected;

    [SerializeField] private Grave _grave;


    public List<Artefacte> InventoryPlayer
    {
        get { return _inventoryPlayer; }
    }

    public int SelectedPerk
    {
        get { return _selectedPerk; }
        set
        {
            _selectedPerk = value;
        }
    }

    public Artefacte ArtefactYouLook { get => _artefactYouLook; set => _artefactYouLook = value; }
    public Artefacte ArtefactSelected { get => _artefactSelected; set => _artefactSelected = value; }

    void Start()
    {
        _destination = BoardManager.Instance.GetCellPos(_cellOn);
        _selectedPerk = 0;
        _myState = PlayerState.idle;
        _grave = new Grave(CaseType.Grave, false, false, 1, null, Vector2.zero, null, 1);
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


    
    /*public bool HasKey()
    {
        
    }*/

    public bool GetDirections(Vector2 direction)
    {
        bool result = false;
        if (_myState == PlayerState.idle)
        {
            switch (direction.y)
            {
                case 1:
                    if (BoardManager.Instance.FindNeighbourCell(Direction.north, _cellOn) != null && BoardManager.Instance.FindNeighbourCell(Direction.north,_cellOn).IsWalkableByPlayer)
                    {
                        _destination = BoardManager.Instance.FindNeighbourCell(Direction.north, _cellOn).WorldPos;
                        _cellOn = BoardManager.Instance.FindNeighbourCell(Direction.north, _cellOn).GetPosInGrid();
                        result = true;
                    }
                    break;

                case -1:
                    if (BoardManager.Instance.FindNeighbourCell(Direction.south, _cellOn) != null && BoardManager.Instance.FindNeighbourCell(Direction.south, _cellOn).IsWalkableByPlayer)
                    {
                        _destination = BoardManager.Instance.FindNeighbourCell(Direction.south, _cellOn).WorldPos;
                        _cellOn = BoardManager.Instance.FindNeighbourCell(Direction.south, _cellOn).GetPosInGrid();
                        result = true;
                    }
                    break;
            }

            switch (direction.x)
            {
                case 1:
                    if (BoardManager.Instance.FindNeighbourCell(Direction.est, _cellOn) != null && BoardManager.Instance.FindNeighbourCell(Direction.est, _cellOn).IsWalkableByPlayer)
                    {
                        _destination = BoardManager.Instance.FindNeighbourCell(Direction.est, _cellOn).WorldPos;
                        _cellOn = BoardManager.Instance.FindNeighbourCell(Direction.est, _cellOn).GetPosInGrid();
                        result = true;
                    }
                    break;

                case -1:
                    if (BoardManager.Instance.FindNeighbourCell(Direction.west, _cellOn) != null && BoardManager.Instance.FindNeighbourCell(Direction.west, _cellOn).IsWalkableByPlayer)
                    {
                        _destination = BoardManager.Instance.FindNeighbourCell(Direction.west, _cellOn).WorldPos;
                        _cellOn = BoardManager.Instance.FindNeighbourCell(Direction.west, _cellOn).GetPosInGrid();
                        result = true;
                    }
                    break;
            }
            _myState = PlayerState.moving;
        }
        return result;
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
        _artefactSelected = _artefactYouLook;
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
        if (_inventoryPlayer.Count == 0) { return 0; }
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

    public void SetCellOn(int newCellPos) { _cellOn = newCellPos; }

    public int GetPerkLimit() { return _perkLimit; }

}

public enum PlayerState
{
    idle, moving,
}

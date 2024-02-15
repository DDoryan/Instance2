using System.Collections.Generic;
using UnityEngine;

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


    public delegate void MovePlayerEventDelegate();
    public event MovePlayerEventDelegate MovePlayerEvent;
    public delegate void GetTreasureEventDelegate();
    public event GetTreasureEventDelegate GetTreasurePlayerEvent;
    public delegate void SetInventoryEventDelegate();
    public event SetInventoryEventDelegate SetInventoryEvent;

    [SerializeField] private Artefacte _artefact;

    private Artefacte _artefactYouLook;
    [SerializeField] private Artefacte _artefactSelected;
    [SerializeField] private GameObject _UiTreasure;


    [SerializeField] private AudioClip _graveSfx;
    [SerializeField] private AudioClip _graveStoneSfx;

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
        _UiTreasure.SetActive(false);
        _destination = BoardManager.Instance.GetCellPos(_cellOn);
        _selectedPerk = 0;
        _myState = PlayerState.idle;
    }

    private void FixedUpdate()
    {
        switch (_myState)
        {
            case PlayerState.moving:
                _playerPos.position = _destination;
                MovePlayerEvent?.Invoke();
                _myState = PlayerState.idle;
                break;
            default:
                break;
        }
    }


    public bool GetDirections(Vector2 direction)
    {
        if (_myState == PlayerState.idle)
        {
            Case caseToCheck = null;
            switch (direction.y)
            {
                case 1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.north, _cellOn);
                    break;

                case -1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.south, _cellOn);
                    break;
            }

            switch (direction.x)
            {
                case 1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.est, _cellOn);
                    break;

                case -1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.west, _cellOn);
                    break;
            }

            if (caseToCheck != null )
            {
                switch (caseToCheck.CaseType)
                {
                    case CaseType.Path:
                        SetDestination(caseToCheck);
                        _myState = PlayerState.moving;
                        return true;

                    case CaseType.Wall:
                        return false;

                    case CaseType.Grave:
                        Grave grave = (Grave)caseToCheck;
                        if (grave.CanInteract)
                        {
                            SoundManager.Instance.PlaySfx(_graveSfx);
                            OpenGrave(grave);
                            return true;
                        }
                        return false;
                    case CaseType.Gravestone:
                        GraveStone graveStone = (GraveStone)caseToCheck;
                        if (graveStone.CanInteract && _canOpenTombs && IsCardInInventory(CardType.Key))
                        {
                            RemoveFromInventory(CardType.Key);
                            if (graveStone.Interact())
                            {
                                SoundManager.Instance.PlaySfx(_graveStoneSfx);
                                _UiTreasure.SetActive(true);
                                GetTreasurePlayerEvent?.Invoke();
                            }
                            return true;
                        }
                        return false;
                }
            }
        }
        return false;
    }

    public void SetDestination(Case caseToCheck)
    {
        _destination = caseToCheck.WorldPos;
        _cellOn = caseToCheck.GetPosInGrid();
    }

    /*private void SetDestination()
    {

    }*/


    public void OpenGrave(Grave caseToCheck)
    {
        if (_inventoryPlayer.Count < _perkLimit)
        {
            Artefacte cardToAdd = caseToCheck.Interact();
            if (cardToAdd.CardType != CardType.Empty)
            {
                _inventoryPlayer.Add(cardToAdd);
            }

        }
        else if (_inventoryPlayer.Count >= _perkLimit && _artefact == null)
        {
            _artefactFull = true;
            _artefact = caseToCheck.Interact();
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

    public bool IsCardInInventory(CardType cardType)
    {
        for (int i = 0; i < _inventoryPlayer.Count; i++)
        {
            if (_inventoryPlayer[i].CardType == cardType)
            {
                return true;
            }
        }
        return false;
    }

    public bool RemoveFromInventory(CardType cardType)
    {
        for (int i = 0; i < _inventoryPlayer.Count; i++)
        {
            if (_inventoryPlayer[i].CardType == cardType)
            {
                _inventoryPlayer.RemoveAt(i);
                SetInventoryEvent?.Invoke();
                return true;
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

    public bool OnPasseMurailleEvent(Vector2 direction)
    {
        if (_myState == PlayerState.idle)
        {
            Case caseToCheck = null;
            Direction dir = Direction.north;
            switch (direction.y)
            {
                case 1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.north, _cellOn);
                    dir = Direction.north;
                    break;

                case -1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.south, _cellOn);
                    dir = Direction.south;
                    break;
            }

            switch (direction.x)
            {
                case 1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.est, _cellOn);
                    dir = Direction.est;
                    break;

                case -1:
                    caseToCheck = BoardManager.Instance.FindNeighbourCell(Direction.west, _cellOn);
                    dir = Direction.west;
                    break;
            }

            if (caseToCheck != null)
            {
                switch (caseToCheck.CaseType)
                {
                    case CaseType.Path:
                        return false;

                    case CaseType.Wall:
                        if (BoardManager.Instance.FindNeighbourCell(dir, caseToCheck.GetPosInGrid()).CaseType == CaseType.Path)
                        {
                            SetDestination(BoardManager.Instance.FindNeighbourCell(dir, caseToCheck.GetPosInGrid()));
                            _myState = PlayerState.moving;
                            return true;
                        }
                        return false;

                    case CaseType.Grave:
                        if (BoardManager.Instance.FindNeighbourCell(dir, caseToCheck.GetPosInGrid()).CaseType == CaseType.Path)
                        {
                            SetDestination(BoardManager.Instance.FindNeighbourCell(dir, caseToCheck.GetPosInGrid()));
                            _myState = PlayerState.moving;
                            return true;
                        }
                        return false;
                }
            }
        }
        return false;
    }

}

public enum PlayerState
{
    idle, moving,
}

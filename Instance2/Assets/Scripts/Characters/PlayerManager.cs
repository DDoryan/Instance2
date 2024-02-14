// Ignore Spelling: Substract Ammount

using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : Entity
{
    #region MouvementEvent
    public delegate void MovementEventDelegate();
    public event MovementEventDelegate MovementEvent;
    #endregion

    #region ActionEvent
    public delegate void ActionEventDelegate();
    public event ActionEventDelegate ActionEvent;
    #endregion

    #region ExchangeEvent
    public delegate void ExchangeEventDelegate();
    public event ExchangeEventDelegate ExchangeEvent;
    public delegate void ExchangeEndEventDelegate();
    public event ExchangeEventDelegate ExchangeEndEvent;
    public delegate void NavEventDelegateExchange();
    public event NavEventDelegateExchange NavEventExchange;
    public delegate void MovePlayerEventCallDelegate();
    public event MovePlayerEventCallDelegate MovePlayerEventCall;
    

    public delegate void ConfirmeExchangeEventDelegate();
    public event ConfirmeExchangeEventDelegate ConfirmeExchangeEvent;    

    public delegate void AccepteDelegateExchange();
    public event AccepteDelegateExchange AccepteEventExchange;   
    
    public delegate void DeclineExchangeDelegate();
    public event DeclineExchangeDelegate DeclineExchangeEvent;
    #endregion

    #region NavEvent
    public delegate void NavEventDelegate();
    public event NavEventDelegate NavEvent;
    #endregion

    #region ChangePlayerEvent
    public delegate void ChangePlayerEventDelegate();
    public event ChangePlayerEventDelegate ChangePlayerEvent;
    #endregion

    #region Selected Artifact Exchange Event

    public delegate void SelectedArtifactToExchangeDelegate();
    public event SelectedArtifactToExchangeDelegate SelectedArtifactToExchangeEvent;


    #endregion

    #region Refresh UI After Use

    public delegate void RefreshUiAfterUseDelegate();
    public event RefreshUiAfterUseDelegate RefreshUiAfterUse;

    #endregion

    [SerializeField] public int _actionPoints;
    [SerializeField] public int _magicPoints;
    private int _baseAP;
    private int _baseMP;
    [SerializeField] public GameObject Player1Prefab;
    [SerializeField] public GameObject Player2Prefab;
    [SerializeField] private int Player1StartCell;
    [SerializeField] private int Player2StartCell;
    private List<Player> _playerList;
    private Player _player1;
    private Player _player2;
    //private bool _gotTheMoula;
    private int _currentTurn;
    public static PlayerManager Instance;
    private int _exchangeTurn;
    private Don_Du_Ciel _donDuCiel;


    [Header("UIElement")]
    [SerializeField]
    private GameObject _panelP1;
    [SerializeField]
    private GameObject _panelP2;
    [SerializeField]
    private GameObject _panelP3;
    [SerializeField]
    private GameObject _textInventory;

    public List<Player> PlayerList { get { return _playerList; } }

    public int ExchangeTurn { get => _exchangeTurn; set => _exchangeTurn = value; }

    private Passe_Passe _passePasse;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        //_passePasse.PassePasseEvent += OnPassePasseEvent;
        //_donDuCiel.DonDuCielEvent += ExchangeStart;
        _baseAP = _actionPoints;
        _baseMP = _magicPoints;
        GameObject player1 = Instantiate(Player1Prefab, BoardManager.Instance.GetCellPos(Player1StartCell) , Quaternion.identity);
        GameObject player2 = Instantiate(Player2Prefab, BoardManager.Instance.GetCellPos(Player2StartCell) , Quaternion.identity);
        _playerList = new List<Player>();
        _player1 = player1.GetComponent<Player>();
        _player2 = player2.GetComponent<Player>();
        _player1.SetCellOn(Player1StartCell);
        _player2.SetCellOn(Player2StartCell);
        _playerList.Add(_player1);
        _playerList.Add(_player2);
        _player1.MovePlayerEvent += MovePlayerEventCallF;
        _player2.MovePlayerEvent += MovePlayerEventCallF;
        MovePlayerEventCallF();
    }

    private void Update()
    {
        if (_actionPoints == 0)
        {
            _currentTurn = 0;
            _panelP1.SetActive(true);
            _panelP2.SetActive(false);
            EndRound();
            ResetActionPoints();
        }
    }



    #region Return Somethings
    public Artefacte GetArtifactByIndex(int i)
    {
        return _playerList[_currentTurn].GetPerk(i);
    }

    public Sprite GetInventory(int index, int playerInventory)
    {
        return _playerList[playerInventory].InventoryPlayer[index].CardSpriteGrave;
    }

    public Player GetPlayer()
    {
        return _playerList[_currentTurn];
    }

    public int CurrentTurn()
    {
        if (_currentTurn == 0)
        {
            return 0;
        }
        else if (_currentTurn == 1)
        {
            return 1;
        }
        return 2;
    }

    public bool SubstractActionPoints(int value)
    {
        if ((_actionPoints - value) < 0)
        {
            return false;
        }
        else
        {
            _actionPoints -= value;
            MovementEvent?.Invoke();
            return true;
        }
    }

    public bool AddActionPoints(int value)
    {
        if (_actionPoints >= _baseAP)
        {
            return false;
        }
        else
        {
            _actionPoints += value;
            MovementEvent?.Invoke();
            return true;
        }
    }

    public bool SubstractMagicPoints(int value)
    {
        if ((_magicPoints - value) < 0)
        {
            return false;
        }
        else
        {
            _magicPoints -= value;
            MovementEvent?.Invoke();
            return true;
        }
    }

    public bool AddMagicPoints(int value)
    {
        if (_magicPoints >= _baseMP)
        {
            return false;
        }
        else
        {
            _magicPoints += value;
            MovementEvent?.Invoke();
            return true;
        }
    }

    public int GetPlayerPerkLimit()
    {
        return _playerList[_currentTurn].GetPerkLimit();
    }

    public int InventoryAmmount(int j)
    {
        return _playerList[j].InventoryPlayer.Count;
    }



    #endregion

    #region Inventory

    public void NavigatePerksExchange(Vector2 direction, int player)
    {
        if (_playerList[player].SelectedPerk + direction.x.ConvertTo<int>() < _playerList[player].InventoryPlayer.Count && _playerList[player].SelectedPerk + direction.x.ConvertTo<int>() >= 0)
        {
            if (!_playerList[player].InventoryPlayer[_playerList[player].SelectedPerk + direction.x.ConvertTo<int>()].IsUnityNull())
            {
                _playerList[player].SelectedPerk += direction.x.ConvertTo<int>();
                _playerList[player].ArtefactYouLook = _playerList[player].InventoryPlayer[_playerList[player].SelectedPerk];
            }
        }
    }

    public void RefreshUiExchange()
    {
        RefreshUiAfterUse?.Invoke();
    }




    public void RefreshUi(int i, Artefacte artefacte)
    {
        _playerList[i].InventoryPlayer.Remove(artefacte);
        RefreshUiAfterUse?.Invoke();
        ActionEvent?.Invoke();
    }

    public void ActiveInventory()
    {
        _panelP3.SetActive(!_panelP3.activeSelf);
        _textInventory.SetActive(!_textInventory.activeSelf);
    }

    public void SelectedArtifact()
    {
        _playerList[_currentTurn].SelectArtifact();
    }

    public void KeepArtifact()
    {
        _playerList[_currentTurn].KeepArtifact();
        ActionEvent?.Invoke();
    }

    public void DestroyArtifact()
    {
        _playerList[_currentTurn].DestroyArtifact();
        ActionEvent?.Invoke();
    }

    public void NavigatePlayerInventory(Vector2 direction, int player)
    {
        if (!_isTurn || player > 1) { return; }
        if (_playerList[player].IsInventoryEmpty())
        {
            print("inventory empty");
            return;
        }
        NavigatePerksExchange(direction, player);
        NavEvent?.Invoke();
    }

    public void NavigateInventory(Vector2 direction)
    {
        NavigatePlayerInventory(direction, _currentTurn);
    }

    public void NavigateInventoryExchange(Vector2 direction)
    {
        NavigatePlayerInventory(direction, _exchangeTurn);
        NavEventExchange?.Invoke();
    }

    #endregion



    #region Event Call
    public void ExchangeStart()
    {
        _exchangeTurn = 0;
        ExchangeEvent?.Invoke();
    }

    public void AccepteExchange()
    {
        AccepteEventExchange?.Invoke();
        ActionEvent?.Invoke();
    }

    public void DeclineExchange()
    {
        DeclineExchangeEvent?.Invoke();
        ActionEvent?.Invoke();
    }


    public void ExchangeEnd()
    {
        ExchangeEndEvent?.Invoke();
        ActionEvent?.Invoke();
    }

    public void SelectArtifactToExchange()
    {
        _playerList[_exchangeTurn].ArtefactSelected = _playerList[_exchangeTurn].ArtefactYouLook;
        _playerList[_exchangeTurn].ArtefactYouLook = null;
        SelectedArtifactToExchangeEvent?.Invoke();
        ConfirmeExchangeEvent?.Invoke();
        _exchangeTurn++;
    }

    #endregion


    public void ResetActionPoints()
    {
        _actionPoints = _baseAP;
        MovementEvent?.Invoke();
    }

    public void MovePlayer(Vector2 direction)
    {
        if (_isTurn)
        {
            if (_playerList[_currentTurn].GetDirections(direction))
            {
                SubstractActionPoints(1);
            }
            ActionEvent?.Invoke();
            return;
        }
    }

    public void CastSpell()
    {
        if (!_isTurn)
        {
            return;
        }
        _playerList[_currentTurn].CastSpell(_magicPoints);
        MovementEvent?.Invoke();
    }

    public void PassTurn()
    {
        if (_isTurn)
        {
            if (_currentTurn == 0)
            {
                _currentTurn = 1;
                _playerList[_currentTurn].SelectedPerk = 0;
                _panelP1.SetActive(false);
                _panelP2.SetActive(true);
                return;
            }
            if (_currentTurn == 1)
            {
                _currentTurn = 0;
                _playerList[_currentTurn].SelectedPerk = 0;
                _panelP1.SetActive(true);
                _panelP2.SetActive(false);
                EndRound();
                ResetActionPoints();
            }
            ChangePlayerEvent?.Invoke();
        }
    }

    public Player GetPlayerByInd(int ind)
    {
        if (ind < 0 || ind > _playerList.Count)
        {
            return null;
        }
        return _playerList[ind];
    }

    private void MovePlayerEventCallF()
    {
        MovePlayerEventCall?.Invoke();
    }

    public void OnPasseMurailleEvent(Vector2 direction)
    {
        if (_isTurn)
        {
            if (_playerList[_currentTurn].OnPasseMurailleEvent(direction))
            {
                SubstractMagicPoints(2);
            }
            ActionEvent?.Invoke();
            return;
        }
    }

    private void OnPassePasseEvent()
    {
        if (_isTurn)
        {
            Case _tempCase = BoardManager.Instance.GetCell(_playerList[0].GetCellOn());
            _playerList[0].SetDestination(BoardManager.Instance.GetCell(_playerList[1].GetCellOn()));
            _playerList[1].SetDestination(_tempCase);
        }
    }
}

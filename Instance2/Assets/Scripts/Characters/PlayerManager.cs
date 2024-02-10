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

    [SerializeField] public int _actionPoints;
    [SerializeField] public int _magicPoints;
    private int _baseAP;
    private int _baseMP;
    [SerializeField] public GameObject Player1Prefab;
    [SerializeField] public GameObject Player2Prefab;
    [SerializeField] private Transform Player1StartPosition;
    [SerializeField] private Transform Player2StartPosition;
    private List<Player> _playerList;
    private Player _player1;
    private Player _player2;
    private bool _gotTheMoula;
    private int _currentTurn;
    public static PlayerManager playerManager;


    [Header("UIElement")]
    [SerializeField]
    private GameObject _panelP1;
    [SerializeField]
    private GameObject _panelP2;
    [SerializeField] 
    private GameObject _panelP3;
    [SerializeField] 
    private GameObject _textInventory;

    public List<Player> PlayerList {  get { return _playerList; } }


    private void Awake()
    {
        if (playerManager == null)
        {
            playerManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _baseAP = _actionPoints;
        _baseMP = _magicPoints;
        GameObject player1 = Instantiate(Player1Prefab, Player1StartPosition);
        GameObject player2 = Instantiate(Player2Prefab, Player2StartPosition);
        _playerList = new List<Player>();
        _player1 = player1.GetComponent<Player>();
        _player2 = player2.GetComponent<Player>();
        _playerList.Add(_player1);
        _playerList.Add(_player2);
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
        if (j == 0)
        {
            return _player1.InventoryPlayer.Count;
        }
        else if (j == 1)
        {
            return _player2.InventoryPlayer.Count;
        }
        return 2;
    }


    #endregion

    #region Inventory
    public void NavigatePerks(Vector2 direction)
    {
        if (_playerList[_currentTurn].SelectedPerk + direction.x.ConvertTo<int>() < _playerList[_currentTurn].InventoryPlayer.Count && _playerList[_currentTurn].SelectedPerk + direction.x.ConvertTo<int>() >= 0)
        {
            if (!_playerList[_currentTurn].InventoryPlayer[_playerList[_currentTurn].SelectedPerk + direction.x.ConvertTo<int>()].IsUnityNull())
            {
                _playerList[_currentTurn].SelectedPerk += direction.x.ConvertTo<int>();
                _playerList[_currentTurn].ArtefactYouLook = _playerList[_currentTurn].InventoryPlayer[_playerList[_currentTurn].SelectedPerk];
            }
        }
    }


    public void ActiveInventory()
    {
        _panelP3.SetActive(!_panelP3.activeSelf);
        _textInventory.SetActive(!_textInventory.activeSelf);
    }

    public void AddToInventory()
    {
        _playerList[_currentTurn].AddToInventory();
        ActionEvent?.Invoke();
    }

    public void SelectedArtifact()
    {
        _playerList[_currentTurn].SelectArtifact();
        SelectedArtifactToExchangeEvent?.Invoke();
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

    public void NavigateInventory(Vector2 direction)
    {
        if (!_isTurn) { return; }
        if (_playerList[_currentTurn].IsInventoryEmpty())
        {
            print("inventory empty");
            return;
        }
        NavigatePerks(direction);
        NavEvent?.Invoke();
    }

    #endregion


    public void ExchangeStart()
    {
        ExchangeEvent?.Invoke();
    }

    public void ExchangeEnd()
    {

    }

    public void ResetActionPoints()
    {
        _actionPoints = _baseAP;
        MovementEvent?.Invoke();
    }

    public void MovePlayer(Vector2 direction)
    {
        if (_isTurn)
        {
            _playerList[_currentTurn].GetDirections(direction);
            SubstractActionPoints(1);
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
                _playerList[_currentTurn].ArtefactYouLook = null;
                _panelP1.SetActive(false);
                _panelP2.SetActive(true);
                return;
            }
            if (_currentTurn == 1)
            {
                _currentTurn = 0;
                _playerList[_currentTurn].ArtefactYouLook = null;
                _panelP1.SetActive(true);
                _panelP2.SetActive(false);
                EndRound();
                ResetActionPoints();
            }
            ChangePlayerEvent?.Invoke();
        }
    }
}

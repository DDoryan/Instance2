using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerManager : Entity
{
    public delegate void MovementEventDelegate();
    public event MovementEventDelegate MovementEvent;
    public delegate void ActionEventDelegate();
    public event ActionEventDelegate ActionEvent;
    public delegate void NavEventDelegate();
    public event NavEventDelegate NavEvent;
    public delegate void ChangePlayerEventDelegate();
    public event ChangePlayerEventDelegate ChangePlayerEvent;
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
    //private bool _gotTheMoula;
    private int _currentTurn;
    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
            EndRound();
            ResetActionPoints();
        }
    }

    public void ResetActionPoints()
    {
        _actionPoints = _baseAP;
        MovementEvent?.Invoke();
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

    public void SelectedArtifact()
    {
        _playerList[_currentTurn].SelectArtifact();
    }

    public void AddToInventory()
    {
        _playerList[_currentTurn].AddToInventory();
        ActionEvent?.Invoke();
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
        _playerList[_currentTurn].NavigatePerks(direction);
        NavEvent?.Invoke();
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
                return;
            }
            if (_currentTurn == 1)
            {
                _currentTurn = 0;
                EndRound();
                ResetActionPoints();
            }
            ChangePlayerEvent?.Invoke();
        }
    }

    public Player GetPlayer()
    {
        return _playerList[_currentTurn];
    }

    public int GetPlayerPerkLimit()
    {
        return _playerList[_currentTurn].GetPerkLimit();
    }

    public Player GetPlayerByInd(int ind)
    {
        if (ind < 0 || ind > _playerList.Count)
        {
            return null;
        }
        return _playerList[ind];
    }
}

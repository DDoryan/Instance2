using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private int _currentTurn;
   private int _turnCounter;

   private List<Entity> _pullOrder;
   private PlayerManager _playerManager;
   [SerializeField] private MenuManager _menuManager;
   
   private TheDeath _theDeath;
   [SerializeField] private GameObject _theDeathPrefab;
   [SerializeField] private int _theDeathStartCell;

    public static GameManager Instance;

    public delegate void DeathSpawnEventDelegate();
    public event DeathSpawnEventDelegate DeathSpawnEvent;

    private bool _getTreasure;
    private bool _loose;

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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _turnCounter = 1;
        _playerManager = PlayerManager.Instance;
        _pullOrder = new List<Entity>();
        _pullOrder.Add(_playerManager);
        _playerManager.NextTurnEvent += Event_NextTurn;
        _playerManager.GetTreasurePlayerEventCall += setGetTreasure;
        _pullOrder[_currentTurn].StartRound();
        _getTreasure = false;
        _loose = false;
    }

    private void Event_NextTurn()
    {
        print(_playerManager.AreBothPlayerOnExit());
        if (_getTreasure && _playerManager.AreBothPlayerOnExit())
        {
            _menuManager.HudVictoryEnable();
        }
        else if (!_loose)
        {
            NextTurn();
        }
    }

    public void NextTurn()
    {
        _currentTurn++;
        _currentTurn %= _pullOrder.Count;
        _pullOrder[_currentTurn].StartRound();

        if (_currentTurn == 0)
        {
            _turnCounter++;
            _playerManager.ResetActionPoints();
        }

        if ( _turnCounter == 3 && _currentTurn == 0)
        {
            GameObject Death = Instantiate(_theDeathPrefab, BoardManager.Instance.GetCellPos(_theDeathStartCell), Quaternion.identity);
            _theDeath = Death.GetComponent<TheDeath>();
            _theDeath.SetCellOn(_theDeathStartCell);
            _theDeath.NextTurnEvent += Event_NextTurn;
            _theDeath.DeathEvent += SendToGameOver;
            _pullOrder.Add(_theDeath);
            DeathSpawnEvent?.Invoke();
        }
        /*Debug.Log("CurrentTurn: " + _currentTurn);
        Debug.Log("TurnCounter: " + _turnCounter);*/
    }

    public int GetCurrentTurn()
    {
        return _currentTurn;
    }

    private void SendToGameOver()
    {
        _menuManager.HudDefeatEnable();
        _loose = true;
    }

    private void setGetTreasure()
    {
        print("inPocket");
        _getTreasure = true;
    }
}
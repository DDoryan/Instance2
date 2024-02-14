using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private int _currentTurn;
   private int _turnCounter;

   private List<Entity> _pullOrder;
   private Entity _specialEventPlayer;
   private Entity _eventPlayerAfterPlayed;
   private PlayerManager _playerManager;
   [SerializeField] private MenuManager _menuManager;
   
   private TheDeath _theDeath;
   [SerializeField] private GameObject _theDeathPrefab;
   [SerializeField] private int _theDeathStartCell;

    private void Start()
    {
        _turnCounter = 1;
        _playerManager = PlayerManager.Instance;
        _pullOrder = new List<Entity>();
        _pullOrder.Add(_playerManager);
        _playerManager.NextTurnEvent += Event_NextTurn;
        _pullOrder[_currentTurn].StartRound();
    }

    private void Event_NextTurn()
    {
        print("aie");
        NextTurn();
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
        }
        /*Debug.Log("CurrentTurn: " + _currentTurn);
        Debug.Log("TurnCounter: " + _turnCounter);*/
    }

    public int GetCurrentTurn()
    {
        return _currentTurn;
    }

    public void SetSpecialEventPlayer(Entity player)
    {
        _specialEventPlayer = player;
    }

    private void SendToGameOver()
    {
        _menuManager.HudDefeatEnable();
    }
}
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
   
   //private TheDeath theDeath;

    private void Start()
    {
        _turnCounter = 1;
        _playerManager = PlayerManager.Instance;
        _pullOrder = new List<Entity>();
        _pullOrder.Add(_playerManager);

        _currentTurn = 0; Debug.Log("CurrentTurn: " + _currentTurn);

        _playerManager.NextTurnEvent += Event_NextTurn;
        _pullOrder[_currentTurn].StartRound();
    }

    private void Event_NextTurn()
    {
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

        if ( _turnCounter == 3)
        {
            //_pullOrder.Add(_theDeath);
        }
        Debug.Log("CurrentTurn: " + _currentTurn);
        Debug.Log("TurnCounter: " + _turnCounter);
    }

    public int GetCurrentTurn()
    {
        return _currentTurn;
    }

    public void SetSpecialEventPlayer(Entity player)
    {
        _specialEventPlayer = player;
    }
}
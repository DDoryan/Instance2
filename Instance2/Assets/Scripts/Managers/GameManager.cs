using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   private int _currentTurn;
   private int _turnCounter;

   private List<Entity> _pullOrder;
   private Entity _specialEventPlayer;
   private Entity _eventPlayerAfterPlayed;

   [SerializeField] public GameObject Player1Prefab;
   [SerializeField] public GameObject Player2Prefab;
    
   [SerializeField] private Transform Player1StartPosition;
   [SerializeField] private Transform Player2StartPosition;

   private Player _player1;
   private Player _player2;
   //private TheDeath theDeath;


    void Awake()
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
        _turnCounter = 1;
        GameObject player1 = Instantiate(Player1Prefab, Player1StartPosition);
        GameObject player2 = Instantiate(Player2Prefab, Player2StartPosition);
        _pullOrder = new List<Entity>();
        _player1 = player1.GetComponent<Player>();
        _player2 = player2.GetComponent<Player>();
        _pullOrder.Add(_player1);
        _pullOrder.Add(_player2);

        _currentTurn = 0; Debug.Log("CurrentTurn: " + _currentTurn);

        _player1.NextTurnEvent += Event_NextTurn;
        _player2.NextTurnEvent += Event_NextTurn;
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
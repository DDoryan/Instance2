using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   private int _currentTurn;
   private int _turnCounter;

   private List<Entity> _pullOrder;
   private Entity _specialEventPlayer;
   private Entity _player1;         // a changer par les commentaires en dessous
   private Entity _player2;
   private Entity _theDeath;
   private Entity _eventPlayerAfterPlayed;

   //private Player player1;
   //private Player player2;
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
        _pullOrder = new List<Entity>();
        _pullOrder.Add(_player1);
        _pullOrder.Add(_player2);
        _pullOrder.Add(_theDeath);

        _currentTurn = 0; Debug.Log("CurrentTurn: " + _currentTurn);

        _player1 = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Entity>();
        _player1.OnFloatEvent += Event_NextTurn;
    }

    private void Event_NextTurn()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        _currentTurn++;
        _currentTurn %= 4;
        //pullOrder[currentTurn] = pullOrder[currentTurn % pullOrder.Count]; //.StartRound()

        Debug.Log("CurrentTurn: " + _currentTurn);

        //pullOrder[currentTurn].StartRound();
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
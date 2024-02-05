using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    public delegate void TestEventDelegate();
    public event TestEventDelegate OnFloatEvent;
    //public event Action<bool, int> OnActionEvent;

    protected bool _isTurn;


    private void Start()
    {
        _isTurn = false;
    }

    public void StartRound()
    {
        _isTurn = true;
    }

    public void EndRound()
    {
        _isTurn = false;

        //Event
        OnFloatEvent?.Invoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RollDiceManager : MonoBehaviour
{
    private RollDice _dice;

    [Header("Dices Reference")]
    [SerializeField] private short _numberOfFaces;
    [SerializeField] private GameObject _d4_Object;
    [SerializeField] private GameObject _d20_Object;

    void Start()
    {
        _d4_Object.gameObject.SetActive(false);
        _d20_Object.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DiceThrow(_numberOfFaces);
        }
    }


    public void DiceThrow(short numberOfFaces)
    {
        WichDice(numberOfFaces);
        _dice.RollingDice();
    }

    private void WichDice(short numberOfFaces)
    {
        _d4_Object.gameObject.SetActive(numberOfFaces == 4);
        _d20_Object.gameObject.SetActive(numberOfFaces == 20);
        
        _dice = GameObject.FindObjectOfType<RollDice>();
    }
}
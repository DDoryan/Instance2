using System.Collections;
using System.Collections.Generic;
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
        _d4_Object.gameObject.SetActive(true);
        _d20_Object.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(DiceThrow(_numberOfFaces)); // je veux recuperer la variable une fois que le des donne un nouveau resultat
        }
    }


    public int DiceThrow(short numberOfFaces)
    {
        WichDice(numberOfFaces);
        return _dice.RollDice_GetNumber();
    }

    private void WichDice(short numberOfFaces)
    {
        _d4_Object.gameObject.SetActive(numberOfFaces == 4);
        _d20_Object.gameObject.SetActive(numberOfFaces == 20);
        
        _dice = GameObject.FindObjectOfType<RollDice>();
    }
}
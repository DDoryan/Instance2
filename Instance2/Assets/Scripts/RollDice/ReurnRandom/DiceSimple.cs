using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSimple : MonoBehaviour
{
    private int _diceNumber;

    public void RollDice()
    {
        _diceNumber = Random.Range(1, 20);
        //return 0;
    }

    public int GetDiceNumber()
    {
        return _diceNumber;
    }
}

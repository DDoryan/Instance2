using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceSimple : MonoBehaviour
{
    private int _diceNumber;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private string _textBeforeValue = "Dice Number : ";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice(6);
        }
        
        if (_diceNumber != 0)
        {
            _scoreText.text = _textBeforeValue + " " + _diceNumber;
        }
    }

    public void RollDice(int numberOfSide)
    {
        _diceNumber = Random.Range(1, numberOfSide);
        //return 0;
    }

    public int GetDiceNumber()
    {
        return _diceNumber;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreDice : MonoBehaviour
{
    private RollDice _dice;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private string _textBeforeValue = "Dice Number : ";

    private void Awake()
    {
        _dice = FindObjectOfType<RollDice>();
    }

    private void Update()
    {
        if (_dice != null)
        {
            if (_dice.DiceFaceNum != 0)
            {
                _scoreText.text = _textBeforeValue + _dice.DiceFaceNum.ToString();
            }
        }
    }
}
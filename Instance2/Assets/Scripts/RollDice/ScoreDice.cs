using TMPro;
using UnityEngine;

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
            if (_dice.GetDiceFaceNum() != 0)
            {
                _scoreText.text = _textBeforeValue + _dice.GetDiceFaceNum();
            }
        }
    }
}
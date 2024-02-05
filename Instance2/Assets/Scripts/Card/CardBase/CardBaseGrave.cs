using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBaseGrave : MonoBehaviour
{
    protected CardType _cardType;

    [SerializeField]
    protected Sprite _cardSpriteGrave;
    
}

public enum CardType
{
    Key,
    Perk,
    Mob
}
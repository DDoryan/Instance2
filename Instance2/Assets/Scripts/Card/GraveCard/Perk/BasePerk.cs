using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePerk : CardBaseGrave
{
    private void Awake()
    {
        _cardType = CardType.Perk;
    }

}

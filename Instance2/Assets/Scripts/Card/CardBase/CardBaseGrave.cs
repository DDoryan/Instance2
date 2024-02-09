using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBaseGrave : ScriptableObject
{
    [SerializeField]


    protected CardType _cardType;

    [SerializeField]
    protected Sprite _cardSpriteGrave;

    public CardType CardType
    {
        get { return _cardType; }
    }

    public Sprite CardSpriteGrave
    {
        get { return _cardSpriteGrave; }
    }
}
public enum CardType
{
    Key,
    Mob,
    All_in,
    PasseMuraille,
    TrompeLaMort,
    Halte_La,
    Temps_Mort,
    Eau_Benite,
    Teleportation,
    Don_du_ciel,
    Entrave,
    Passe_Passe
}
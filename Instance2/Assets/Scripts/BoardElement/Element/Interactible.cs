// Ignore Spelling: Interactible
// Ignore Spelling: Trigerred
// Ignore Spelling: triggerd

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Interactible : Case
{
    protected bool _canInteract;

    protected Sprite _isTrigerredSprite;

    protected Deck _deck;


    protected Interactible(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector2 worldPos, Sprite triggerdSprite, int posInGrid) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, posInGrid)
    {
        _canInteract = true;
        _isTrigerredSprite = triggerdSprite;
        _deck = Deck.GraveDeck;
    }


    #region Getter & Getter

    #region Getter


    public bool IsTrigerredSprite
    {
        get { return _isTrigerredSprite; }
    }
    #endregion


    #region Setter


    public bool CanInteract
    {
        get { return _canInteract; }
        set
        {
            _canInteract = value;
        }
    }

    #endregion


    #endregion


}

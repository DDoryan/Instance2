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

    protected Deck _deck;


    protected Interactible(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector2 worldPos, int posInGrid) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, posInGrid)
    {
        _canInteract = true;
        _deck = Deck.GraveDeck;
    }


    #region Getter & Getter

    #region Getter

    public bool CanInteract
    {
        get { return _canInteract; }
    }
    #endregion

    #endregion


}

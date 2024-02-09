using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grave : Interactible
{
    public Grave(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector2 worldPos, Sprite triggerdSprite,int posInGrid) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, triggerdSprite, posInGrid)
    {

    }

    public Artefacte Interact()
    {
        if (_canInteract)
        {
            _defaultSprite = _isTrigerredSprite;
            Artefacte card = Deck.GraveDeck.GetRandomCard();
            //Debug.Log("c'est bon");
            _canInteract = false;
            return card;
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grave : Interactible
{
    public Grave(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector2 worldPos, Sprite triggerdSprite) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, triggerdSprite)
    {

    }

    public CardBaseGrave Interact()
    {
        if (_canInteract)
        {
            _defaultSprite = _isTrigerredSprite;
            CardBaseGrave card = Deck.GraveDeck.GetRandomCard();
            Debug.Log("c'est bon");
            _canInteract = false;
            return card;
        }
        return null;
    }
}

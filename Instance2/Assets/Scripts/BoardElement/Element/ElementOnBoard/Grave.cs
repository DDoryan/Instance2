using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grave : Interactible
{
    public Grave(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector2 worldPos, int posInGrid) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, posInGrid)
    {

    }

    public Artefacte Interact()
    {
        BoardManager.Instance.ChangeSpriteToDestroyed(WorldPos);
        Artefacte card = Deck.GraveDeck.GetRandomCard();
        _canInteract = false;
        return card;
    }
}

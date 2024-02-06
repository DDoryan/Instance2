using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grave : Interactible
{
    public Grave(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, Tile myTile, Vector2 worldPos, Sprite triggerdSprite) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, triggerdSprite)
    {

    }

    public override void Interact()
    {
        if (_canInteract)
        {
            CardBaseGrave card = Deck.GraveDeck.GetRandomCard();
            Inventory.InventoryInstance.AddToInventory(card);
            Debug.Log("c'est bon");
            _canInteract = false;
        }
    }
}

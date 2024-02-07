using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraveStone : Interactible
{
    public GraveStone(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, Tile myTile, Vector2 worldPos, Sprite triggerdSprite) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, triggerdSprite)
    {

    }

    public override void Interact()
    {
        if (_canInteract)
        {
            _canInteract = false;
        }
    }
}

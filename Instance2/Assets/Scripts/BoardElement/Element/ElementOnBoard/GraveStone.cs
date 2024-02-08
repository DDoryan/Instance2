using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GraveStone : Interactible
{
    public GraveStone(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector2 worldPos, Sprite triggerdSprite) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, triggerdSprite)
    {
        _caseType = myType;
        _isWalkableByDeath = walkableDeath;
        _isWalkableByPlayer = walkablePlayer;
        _area = area;
        _myTile = myTile;
        _worldPos = worldPos;
    }

    public bool Interact()
    {
        if (_canInteract)
        {
            _defaultSprite = _isTrigerredSprite;
            bool _treasure = Deck.GraveDeck.GetRandomTreasure();
            _canInteract = false;
            return _treasure;
        }
        return false;
    }
}

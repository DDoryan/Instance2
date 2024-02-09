using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : Swapable
{
    public Door(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector3 worldPos, int indexInGrid) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos, indexInGrid)
    {
        _caseType = myType;
        _isWalkableByDeath = walkableDeath;
        _isWalkableByPlayer = walkablePlayer;
        _area = area;
        _myTile = myTile;
        _worldPos = worldPos;
    }

    protected override void WalkableByDeath(bool IsWalkable)
    {
        base.WalkableByDeath(IsWalkable);
    }

    protected override void WalkableByPlayer(bool IsWalkable)
    {
        base.WalkableByPlayer(IsWalkable);
    }
}

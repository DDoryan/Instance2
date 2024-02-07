using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fire : Swapable
{
    public Fire(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector3 worldPos) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos)
    {
        _caseType = myType;
        _isWalkableByDeath = walkableDeath;
        _isWalkableByPlayer = walkablePlayer;
        _area = area;
        _myTile = myTile;
        _worldPos = worldPos;
    }

    protected override void WalkableByPlayer(bool IsWalkable)
    {
        base.WalkableByPlayer(IsWalkable);
    }

    protected override void WalkableByDeath(bool IsWalkable)
    {
        base.WalkableByDeath(IsWalkable);
    }
}

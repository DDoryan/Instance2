using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : Swapable
{
    public Door(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, Tile myTile, Vector3 worldPos) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos)
    {
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

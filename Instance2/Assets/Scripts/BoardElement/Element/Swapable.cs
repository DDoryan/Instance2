// Ignore Spelling: Swapable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Swapable : Case
{
    protected Sprite _sprite;

    public Swapable(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector3 worldPos) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos)
    {
    }


    #region Getter

    public Sprite SpriteActive
    {
        get { return _sprite; }
    }

    #endregion

    protected virtual void WalkableByPlayer(bool IsWalkable)
    {

    }
    protected virtual void WalkableByDeath(bool IsWalkable)
    {

    }
}

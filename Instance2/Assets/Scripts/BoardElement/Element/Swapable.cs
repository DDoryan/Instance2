// Ignore Spelling: Swapable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapable : Case
{
    protected Sprite _sprite;


    #region Getter

    public Sprite Sprite
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

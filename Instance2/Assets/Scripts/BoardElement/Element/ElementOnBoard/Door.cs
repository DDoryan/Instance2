using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Swapable
{
    private void Awake()
    {
        _caseType = CaseType.Door;
        _isWalkableByDeath = true;
        _isWalkableByPlayer = true;
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

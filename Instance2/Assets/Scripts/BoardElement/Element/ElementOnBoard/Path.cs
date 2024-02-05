using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : Swapable
{
    private void Awake()
    {
        _caseType = CaseType.Path;
        _isWalkableByDeath = true;
        _isWalkableByDeath = true;
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

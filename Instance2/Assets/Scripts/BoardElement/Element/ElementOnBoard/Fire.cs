using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Swapable
{
    private void Awake()
    {
        _caseType = CaseType.Fire;
        _isWalkableByDeath = true;
        _isWalkableByPlayer = true;
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

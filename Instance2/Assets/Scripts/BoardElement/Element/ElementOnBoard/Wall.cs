using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Case
{
    private void Awake()
    {
        _caseType = CaseType.Wall;
        _isWalkableByDeath = false;
        _isWalkableByPlayer = false;
    }
    
    
    
}

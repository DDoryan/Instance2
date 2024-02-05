using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : Case
{
    private void Awake()
    {
        _caseType = CaseType.Beacon; 
        _isWalkableByDeath = true;
        _isWalkableByPlayer = true;
    }
}

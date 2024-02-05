using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : Interactible
{
    private void Awake()
    {
        _canInteract = true;
        _caseType = CaseType.Gravestone;
        _isWalkableByPlayer = false;
        _isWalkableByDeath = false;
    }

    protected override void Interact()
    {
        base.Interact();
    }
}

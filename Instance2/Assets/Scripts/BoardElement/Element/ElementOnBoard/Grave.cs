using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : Interactible
{
    private List<int> _graves;




    private void Awake()
    {
        _canInteract = true;
        _caseType = CaseType.Grave;
        _isWalkableByPlayer = false;
        _isWalkableByDeath = false;
    }

    protected override void Interact()
    {
        base.Interact();
        if (_canInteract)
        {
            RandomCard();
            _canInteract = false;
        }
    }


    private void RandomCard()
    {

    }
}

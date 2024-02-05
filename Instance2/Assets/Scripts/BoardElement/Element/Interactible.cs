// Ignore Spelling: Interactible
// Ignore Spelling: Trigerred

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : Case
{
    protected bool _canInteract;

    protected Sprite _isTrigerredSprite;

    protected virtual void Interact()
    {

    }


}

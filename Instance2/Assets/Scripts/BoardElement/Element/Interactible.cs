// Ignore Spelling: Interactible
// Ignore Spelling: Trigerred

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : Case
{
    protected bool _canInteract;

    protected Sprite _isTrigerredSprite;

    #region Getter

    public bool CanInteract
    {
        get { return _canInteract; }
    }

    public bool IsTrigerredSprite
    {
        get { return _isTrigerredSprite; }
    }

    #endregion

    protected virtual void Interact()
    {

    }


}

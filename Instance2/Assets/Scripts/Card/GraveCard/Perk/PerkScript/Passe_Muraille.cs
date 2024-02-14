// Ignore Spelling: Passe, Muraille


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passe_Muraille : BasePerk
{
    public delegate void PasseMurailleEventDelegate();
    public event PasseMurailleEventDelegate PasseMurailleEvent;
    public override void Use()
    {
        _cost = 2;
        PasseMurailleEvent?.Invoke();
    }
}

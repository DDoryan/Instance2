// Ignore Spelling: Passe



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passe_Passe : BasePerk
{
    public delegate void PassePasseEventDelegate();
    public event PassePasseEventDelegate PassePasseEvent;
    public override void Use()
    {
        _cost = 4;
        PassePasseEvent?.Invoke();
    }
}

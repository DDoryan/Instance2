using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrave : BasePerk
{
    public delegate void EntraveEventDelegate();
    public event EntraveEventDelegate EntraveEvent;
    public override void Use()
    {
        _cost = 4;
        EntraveEvent?.Invoke();   
    }
}

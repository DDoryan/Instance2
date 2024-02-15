using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temps_Mort : BasePerk
{
    public delegate void TempsMortEventDelegate();
    public event TempsMortEventDelegate TempsMortEvent;
    public override void Use()
    {
        _cost = 6;
        TempsMortEvent?.Invoke();   
    }
}

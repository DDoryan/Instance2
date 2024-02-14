using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Don_Du_Ciel : BasePerk
{
    public delegate void DonDuCielEventDelegate();
    public event DonDuCielEventDelegate DonDuCielEvent;
    public override void Use()
    {
        _cost = 3;
        DonDuCielEvent?.Invoke();   
    }
}

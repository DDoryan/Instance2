using System;
using Unity.VisualScripting;
using UnityEngine;

public class ArmurePossedee : MOB
{
    public override void DoEvent()
    {
        _minNumberRequiredToWin = 12;
        _damagePa = 3;

        Debug.Log(GetType().Name);
        base.DoEvent();
    }
}
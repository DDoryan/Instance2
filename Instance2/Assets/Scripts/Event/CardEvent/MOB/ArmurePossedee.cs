using System;
using Unity.VisualScripting;
using UnityEngine;

public class ArmurePossedee : MOB
{
    

    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
        base.DoEvent();
    }

/*    public override void OnDiceStopped(int num)
    {
        base.OnDiceStopped(num);
    }*/
}
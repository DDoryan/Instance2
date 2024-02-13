using UnityEngine;

public class EspritFrappeur : MOB
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
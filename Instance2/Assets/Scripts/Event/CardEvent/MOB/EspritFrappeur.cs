using UnityEngine;

public class EspritFrappeur : MOB
{
    public override void DoEvent()
    {
        _minNumberRequiredToWin = 11;
        _damagePa = 3;

        Debug.Log(GetType().Name);
        base.DoEvent();
    }
}
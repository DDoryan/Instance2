using UnityEngine;

public class EspritFrappeur : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
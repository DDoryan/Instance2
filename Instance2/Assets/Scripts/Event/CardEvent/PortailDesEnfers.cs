using UnityEngine;

public class PortailDesEnfers : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
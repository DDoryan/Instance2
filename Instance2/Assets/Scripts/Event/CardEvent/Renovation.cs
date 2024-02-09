using UnityEngine;

public class Renovation : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
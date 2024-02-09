using UnityEngine;

public class Benediction : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
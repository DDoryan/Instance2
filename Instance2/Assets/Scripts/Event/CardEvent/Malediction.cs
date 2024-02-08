using UnityEngine;

public class Malediction : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
using UnityEngine;

public class TransPosition : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
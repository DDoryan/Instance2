using UnityEngine;

public class TempsMort : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
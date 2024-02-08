using UnityEngine;

public class VisteSurprise : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
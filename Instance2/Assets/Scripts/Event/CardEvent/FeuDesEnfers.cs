using UnityEngine;

public class FeuDesEnfers : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}
using UnityEngine;

public class ArmurePossedee : EventCard
{
    public override void DoEvent()
    {
        Debug.Log(GetType().Name);
    }
}

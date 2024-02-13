using UnityEngine;

public abstract class EventCard : ScriptableObject
{
    public virtual void DoEvent() 
    { 
        Debug.Log("Vous avez piochez la carte " + GetType().Name);
    }
}
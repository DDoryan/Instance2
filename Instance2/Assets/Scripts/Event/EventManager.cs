using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EventName
{
    ArmurePossedee,
    Benediction,
    EspritFrappeur,
    FermetureDesPortes,
    FeuDesEnfers,
    Malediction,
    PortailDesEnfers,
    Renovation,
    TempsMort,
    TransPosition,
    VisteSurprise,
}

public class EventManager : Entity
{
    private List<EventCard> _listCards;
    private int _indexEvent;

    private void Start()
    {
        _listCards = new List<EventCard>();
        InitEvent();
    }

    public override void StartRound()
    {
        PullEvent();
    }

    public void InitEvent()
    {
        foreach (EventName name in System.Enum.GetValues(typeof(EventName)))
        {
            EventCard eventCard = (EventCard)Activator.CreateInstance(Type.GetType(name.ToString()));
            _listCards.Add(eventCard);
        }
        
        foreach (EventCard eventCard in _listCards)
        {
            if (eventCard is MOB mobCard)
            {
                mobCard.OnDiceStoppedEvent += EndEvent;
            }
        }
    }

    public void PullEvent()
    {
        if (_listCards.Count <= 0)
        {
            InitEvent();
        }
        _indexEvent = UnityEngine.Random.Range(0, _listCards.Count);

        EventCard eventCard = _listCards[_indexEvent];
        eventCard.DoEvent();

        EventCard tmp = _listCards[_indexEvent];
        _listCards.RemoveAt(_indexEvent);
        Destroy(tmp);

        
    }

    public void EndEvent()
    {
        EndRound();
    }
}
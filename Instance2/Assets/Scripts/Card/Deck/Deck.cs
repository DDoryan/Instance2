using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    public static Deck GraveDeck;

    private void Awake()
    {
        if (GraveDeck == null)
            GraveDeck = this;
        else
            Destroy(this);
    }

    [SerializeField]
    private List<CardBaseGrave> _cards;

    private int _indexToReturn;

    public CardBaseGrave GetRandomCard()
    {
        _indexToReturn = Random.Range(0, _cards.Count);
        CardBaseGrave card = _cards[_indexToReturn];
        _cards.RemoveAt(_indexToReturn);
        return card;
    }
}

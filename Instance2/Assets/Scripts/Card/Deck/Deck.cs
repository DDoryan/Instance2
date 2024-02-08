using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deck : MonoBehaviour
{
    public static Deck GraveDeck;

    private List<bool> _graveStone;

    [SerializeField]
    private List<Artefacte> _cards;

    private int _indexToReturn;


    private void Awake()
    {
        if (GraveDeck == null)
            GraveDeck = this;
        else
            Destroy(this);

        _graveStone = new List<bool> { false, false, true };
    }
    public Artefacte GetRandomCard()
    {
        _indexToReturn = Random.Range(0, _cards.Count);
        Artefacte card = _cards[_indexToReturn];
        _cards.RemoveAt(_indexToReturn);
        return card;
    }
    public bool GetRandomTreasure()
    {
        _indexToReturn = Random.Range(0, _graveStone.Count);
        bool _treasure = _graveStone[_indexToReturn];
        _graveStone.RemoveAt(_indexToReturn);
        return _treasure;
    }
}

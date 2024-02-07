using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<CardBaseGrave> _inventoryPlayer1 = new List<CardBaseGrave>();
    [SerializeField]
    private List<CardBaseGrave> _inventoryPlayer2 = new List<CardBaseGrave>();

    public static Inventory InventoryInstance;

    private void Awake()
    {
        if (InventoryInstance == null)
            InventoryInstance = this;
        else
            Destroy(this);
    }

    public List<CardBaseGrave> InventoryPlayer1
    {
        get { return _inventoryPlayer1; }
    }
    public List<CardBaseGrave> InventoryPlayer2
    {
        get { return _inventoryPlayer2; }
    }


    public void AddToInventory(CardBaseGrave card)
    {
        if (GameManager.Instance.GetCurrentTurn() == 0)
            _inventoryPlayer1.Add(card);
        else if(GameManager.Instance.GetCurrentTurn() == 1)
            _inventoryPlayer2.Add(card);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Grave Card/Perk")]

public class BasePerk : CardBaseGrave
{
    private int _cost;

    public int Cost
    {
        get { return _cost; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Grave Card/Artefact's/Perk")]

public class BasePerk : Artefacte
{
    protected int _cost;

    public int Cost
    {
        get { return _cost; }
    }

    protected virtual void Use()
    {

    }
}

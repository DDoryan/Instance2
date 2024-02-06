using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Grave Card/Mob")]

public class Mob : CardBaseGrave
{
    private int _saveValue;

    private int _damage;

    public int SaveValue
    {
        get { return _saveValue; }
    }
    
    public int Damage
    {
        get { return _damage; }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wall : Case
{
    public Wall(CaseType myType, bool walkableDeath, bool walkablePlayer, int area, Tile myTile, Vector3 worldPos) : base(myType, walkableDeath, walkablePlayer, area, myTile, worldPos)
    {
    }
}

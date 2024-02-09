using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    [SerializeField] public TileBase[] tiles;

    [SerializeField] public TileKind id;
}

public enum TileKind
{
    Beacon,
    Door,
    Fire,
    Grave,
    GraveStone,
    Path,
    Wall
}

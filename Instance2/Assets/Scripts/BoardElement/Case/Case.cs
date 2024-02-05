using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Case : MonoBehaviour
{
    protected List<Tile> _neighbor; // getter, pas moi, a faire dans Case

    protected bool _isWalkableByDeath; // getter, pas moi, a faire dans case

    protected int _area;

    protected Tile _myTile; // getter, pas moi, a faire dans Case

    protected bool _isWalkableByPlayer; // getter, pas moi, a faire dans Case

    protected Sprite _defaultSprite; // getter, pas moi, a faire dans Case




    #region Getter & Setter

    #region Getter

    public List<Tile> Neighbor
    {
        get { return _neighbor; }
    }

    public bool IsWalkableByDeath
    {
        get { return _isWalkableByDeath; }
    }

    public Tile MyTile
    {
        get { return _myTile; }
    }

    public bool IsWalkableByPlayer
    {
        get { return _isWalkableByPlayer; }
    }

    public Sprite Sprite
    {
        get { return _defaultSprite; }
    }

    #endregion


    #endregion

}

public enum Nature
{
    Floor,
    Fire,
    Door,
    Path,
    Grave,
    Gravestone,
    Wall,
    Beacon
}


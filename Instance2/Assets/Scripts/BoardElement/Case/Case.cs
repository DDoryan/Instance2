using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Case : MonoBehaviour
{
    protected CaseType _caseType;

    protected List<Tile> _neighbor; // getter et setter , pas moi, a faire dans Case

    protected bool _isWalkableByDeath; // getter, pas moi, a faire dans case

    protected int _area;

    protected Tile _myTile; // getter, pas moi, a faire dans Case

    protected bool _isWalkableByPlayer; // getter, pas moi, a faire dans Case

    [SerializeField]
    protected Sprite _defaultSprite; // getter, pas moi, a faire dans Case




    #region Getter & Setter

    #region Getter

    public bool IsWalkableByDeath
    {
        get { return _isWalkableByDeath; }
    }

    public bool IsWalkableByPlayer
    {
        get { return _isWalkableByPlayer; }
    }

    public Sprite Sprite
    {
        get { return _defaultSprite; }
    }

    public CaseType CaseType
    {
        get { return _caseType; }
    }
    public int Area
    {
        get { return _area; }
    }

    #endregion

    #region Setter & Getter    

    public Tile MyTile
    {
        get { return _myTile; }
        set
        {
            _myTile = value;
        }
    }


    public List<Tile> Neighbor
    {
        get { return _neighbor; }
        set
        {
            _neighbor = value;
        }
    }
    #endregion


    #endregion

}

public enum CaseType
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


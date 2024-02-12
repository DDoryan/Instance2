using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Case 
{
    public Case (CaseType myType, bool walkableDeath, bool walkablePlayer, int area, TileBase myTile, Vector3 worldPos, int indexInGrid)
    {
        _caseType = myType;
        _isWalkableByDeath = walkableDeath;
        _isWalkableByPlayer = walkablePlayer;
        _area = area;
        _worldPos = worldPos;
        _myTile = myTile;
        _indexInGrid = indexInGrid;
    }

    protected CaseType _caseType;

    protected List<Case> _neighbor = new List<Case>(); // getter et setter , pas moi, a faire dans Case

    protected bool _isWalkableByDeath; // getter, pas moi, a faire dans case

    protected int _area;

    protected TileBase _myTile; // getter, pas moi, a faire dans Case

    protected bool _isWalkableByPlayer; // getter, pas moi, a faire dans Case

    protected Vector3 _worldPos;

    protected int _indexInGrid;





    [SerializeField]
    protected Sprite _defaultSprite; // getter, pas moi, a faire dans Case

    public void AddNeighbor(Case neighbor)
    {
        _neighbor.Add(neighbor);
    }

    public void IntroduceYourself()
    {
        Debug.Log("my name is " + _caseType.ToString() + " I got " + _neighbor.Count + " neighbors");
    }


    public int GetPosInGrid()
    {
        return _indexInGrid;
    }


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

    public Vector3 WorldPos
    {
        get { return _worldPos; }
    }

    #endregion

    #region Setter & Getter    

    public TileBase MyTile
    {
        get { return _myTile; }
        set
        {
            _myTile = value;
        }
    }


    public List<Case> Neighbor
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


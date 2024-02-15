using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private List<TileData> _tilesDatas = new List<TileData>();
    [SerializeField] private List<interactibleSpriteContainer> _spriteSwap = new List<interactibleSpriteContainer>();

    private Dictionary<TileBase, interactibleSpriteContainer> _tileSwap = new Dictionary<TileBase, interactibleSpriteContainer> { };

    private Dictionary<TileBase, TileData> _dataFromTiles = new Dictionary<TileBase, TileData>();
    private Dictionary<Vector3Int, Case> _worldToMapInfo = new Dictionary<Vector3Int, Case>();

    private Case[] _mapInfo = new Case[225];

    private Vector3Int _pos;

    private int _lengthLine = 15;

    public static BoardManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (TileData tileData in _tilesDatas)
        {
            foreach (TileBase tile in tileData.tiles)
            {
                _dataFromTiles.Add(tile, tileData);
            }
        }
        // we can now use the tileBase as a way to find the nature of a tile
        
        foreach (interactibleSpriteContainer swap in _spriteSwap)
        {
            _tileSwap.Add(swap.defauldTile,swap);
            _tileSwap.Add(swap.usedTile, swap);
        }
            

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                _pos.Set(i, j, 0);
                
                _mapInfo[ i * _lengthLine + j ] = CreateCase(_dataFromTiles[_tilemap.GetTile(_pos)].id, _tilemap.GetTile(_pos), _tilemap.CellToWorld(_pos) + new Vector3(_tilemap.cellSize.x/2, _tilemap.cellSize.y/2, 0), i * _lengthLine + j);

            }
        }

        InitNeighbor();
    }

    private Case CreateCase(TileKind template, TileBase tileBase, Vector3 worldPos,int posInGrid)
    {
        Case result = null;

        switch (template)
        {
            case TileKind.Path:
                result = new Path(CaseType.Path, true, true, 0, tileBase, worldPos, posInGrid);
                break;

            case TileKind.Wall:
                result = new Wall(CaseType.Wall, false, false, 0, tileBase, worldPos, posInGrid);
                break;
            case TileKind.Grave:
                result = new Grave(CaseType.Grave, false, false, 0, tileBase, worldPos, posInGrid);
                break;
            case TileKind.GraveStone:
                result = new GraveStone(CaseType.Gravestone, false, false, 0, tileBase, worldPos, posInGrid);
                break;
        }

        _worldToMapInfo.Add(_tilemap.WorldToCell(_pos), result);
        return result;
    }

    private void InitNeighbor()
    {
        for (int i = 0; i < 225; i++)
        {
            if (_mapInfo[i].IsWalkableByDeath)
            {
                if (i % _lengthLine != 0 && _mapInfo[i - 1].IsWalkableByDeath)
                {
                    _mapInfo[i].AddNeighbor(_mapInfo[i - 1]);
                }
                if (i % _lengthLine != _lengthLine - 1 && _mapInfo[i + 1].IsWalkableByDeath)
                {
                    _mapInfo[i].AddNeighbor(_mapInfo[i + 1]);
                }
                if (i > _lengthLine - 1 && _mapInfo[i - _lengthLine].IsWalkableByDeath)
                {
                    _mapInfo[i].AddNeighbor(_mapInfo[i - _lengthLine]);
                }
                if (i < _mapInfo.Length - _lengthLine && _mapInfo[i + _lengthLine].IsWalkableByDeath)
                {
                    _mapInfo[i].AddNeighbor(_mapInfo[i + _lengthLine]);
                }
            }
        }
    }

    public Case FindNeighbourCell(Direction dir, int startCellIndex)
    {
        //retourne la case dans la direction indique, ATTENTION, retourne null si la case est hors de la map!!!
        switch (dir) 
        {
            case Direction.north:
                //make sure there's a cell above
                if (startCellIndex % _lengthLine != _lengthLine - 1)
                {
                    return _mapInfo[startCellIndex + 1];
                }
                break;

            case Direction.south:
                if (startCellIndex % _lengthLine != 0)
                {
                    return _mapInfo[startCellIndex - 1];
                }
                break;

            case Direction.west:
                if (startCellIndex > _lengthLine - 1)
                {
                    return _mapInfo[startCellIndex - 15];
                }
                break;

            case Direction.est:
                if (startCellIndex < _mapInfo.Length - _lengthLine)
                {
                    return _mapInfo[startCellIndex + 15];
                }
                break;
        }
        return null;
    }

    public Case GetCell(int cellIndex)
    {
        return _mapInfo[cellIndex];
    }
    public void ChangeSpriteToDestroyed(Vector2 pos)
    {
        _tilemap.SetTile(_tilemap.WorldToCell(pos), _tileSwap[_tilemap.GetTile(_tilemap.WorldToCell(pos))].usedTile);
    }

    public Vector3 GetCellPos(int cellIndex)
    {
        return (_mapInfo[cellIndex].WorldPos);
    }

    public int GetLengthLine() { return _lengthLine; }
}

public enum Direction
{
    north,
    south,
    west,
    est
}



[Serializable]
public struct interactibleSpriteContainer
{
    public TileBase defauldTile;
    public TileBase usedTile;
}

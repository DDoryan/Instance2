using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    private Dictionary<Vector3, Sprite> _map;
    
    private TileBase[] _tiles;
    

    private Tilemap _tilemap;

    private static TileManager _instance;
    private void Awake()
    {
        //Set instance if null
        if (_instance==null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        
        //GetMapSprite();
        
    }

    //Get the local position of each tile and calcul its world position. Then add the world position and the sprite 
    //You can get thanks to the local position of the tile in the tilemap
    private void GetMapSprite()
    {
        for (int n = _tilemap.cellBounds.xMin; n < _tilemap.cellBounds.xMax; n++)
        {
            for (int p = _tilemap.cellBounds.yMin; p < _tilemap.cellBounds.yMax; p++)
            {
                Vector3Int localTilePosition = (new Vector3Int(n, p, (int)_tilemap.transform.position.y));
                Vector3 worldPosition = _tilemap.CellToWorld(localTilePosition);
                if (_tilemap.HasTile(localTilePosition))
                {
                    _map[worldPosition] = _tilemap.GetSprite(localTilePosition);
                }
            }
        }
    }
    
    //Get The sprite of a World Position
    public Sprite GetSpriteByPosition(Vector3 position)
    {
        return _map[position];
    }
    
    //return TileManger Instance
    public TileManager Instance()
    {
        return _instance;
    }
}

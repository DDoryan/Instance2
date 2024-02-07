using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Tilemaps;



enum ISpriteType
{
    Beacon,
    Door,
    Fire,
    Grave,
    GraveStone,
    Path,
    Wall
}
public class TileManager : MonoBehaviour
{

    [SerializeField]private List<Sprite> _beaconSprites, _doorSprites, _fireSprites,_graveSprites,
        _graveStoneSprites, _pathSprites, _wallSprites;
    
    
    
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

    //Get the type of sprite
    private ISpriteType GetSpriteType(Sprite sprite)
    {
        if (_beaconSprites.Contains(sprite))
        {
            return ISpriteType.Beacon;
        }
        else if (_doorSprites.Contains(sprite))
        {
            return ISpriteType.Door;
        }
        else if (_fireSprites.Contains(sprite))
        {
            return ISpriteType.Fire;
        }
        else if(_graveSprites.Contains(sprite))
        {
            return ISpriteType.Grave;
        }
        else if(_pathSprites.Contains(sprite))
        {
            return ISpriteType.Path;
        }
        else if(_wallSprites.Contains(sprite))
        {
            return ISpriteType.Wall;
        }
        else if(_graveStoneSprites.Contains(sprite))
        {
            return ISpriteType.GraveStone;
        }
        
        return ISpriteType.Wall;
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

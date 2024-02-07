using System.Collections.Generic;
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

    [SerializeField]private Sprite _usedGrave, _usedGraveStone;
    
    private Dictionary<Vector3, Sprite> _mapbyposition;
    private Dictionary<Vector3, TileBase> _tilesbyposition;
    private Dictionary<Vector3, List<TileBase>> _neighbor; 
    private Dictionary<Vector3, Case> _map;
    
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
        //SetMapCase();

    }




    private void SetMapCase()
    {
        foreach (var (position, sprite) in _mapbyposition)
        {
            switch (GetSpriteType(sprite))
            {
                case ISpriteType.Beacon:
                    Beacon beacon = new Beacon(CaseType.Beacon, true, true, 0, _tilesbyposition[position], position);
                    _map[position] = beacon;
                    break;
                case ISpriteType.Door:
                    Door door = new Door(CaseType.Door, true, false, 0, _tilesbyposition[position], position);
                    _map[position] = door;
                    break;
                case ISpriteType.Fire:
                    Fire fire = new Fire(CaseType.Fire, true, true, 0, _tilesbyposition[position], position);
                    _map[position] = fire;
                    break;
                case ISpriteType.Grave:
                    Grave grave = new Grave(CaseType.Grave, false, false, 0, _tilesbyposition[position], position, _usedGrave);
                    _map[position] = grave;
                    break;
                case ISpriteType.GraveStone:
                    GraveStone graveStone = new GraveStone(CaseType.Gravestone, false, false, 0, _tilesbyposition[position], position, _usedGraveStone);
                    _map[position] = graveStone;
                    break;
                case ISpriteType.Wall:
                    Wall wall = new Wall(CaseType.Wall, false, false, 0, _tilesbyposition[position], position);
                    _map[position] = wall;
                    break;
                case ISpriteType.Path:
                    Path path = new Path(CaseType.Path, true, true, 0, _tilesbyposition[position], position);
                    _map[position] = path;
                    break;
                default:
                    Debug.Log("Error while creating case !!");
                    break;
            }
            
            
        }
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
                    _mapbyposition[worldPosition] = _tilemap.GetSprite(localTilePosition);
                    _tilesbyposition[worldPosition] = _tilemap.GetTile(localTilePosition);

                    AddNeighbor(worldPosition, localTilePosition);
                }
            }
        }
    }

    //Add the neighbor for a localposition in a tilemap given and add it to a dictionnary with a world positon as a key 
    private void AddNeighbor(Vector3 worldposition, Vector3Int localposition)
    {
        if (_tilemap.GetTile(new Vector3Int(localposition.x - 1, localposition.y,localposition.z)))
        {
            if (!_neighbor.ContainsKey(worldposition))
            {
                _neighbor[worldposition] = new List<TileBase>();
            }
            _neighbor[worldposition].Add(_tilemap.GetTile(new Vector3Int(localposition.x - 1, localposition.y,localposition.z)));
        }

        if (_tilemap.GetTile(new Vector3Int(localposition.x + 1, localposition.y,localposition.z)))
        { 
            if (!_neighbor.ContainsKey(worldposition))
            {
                _neighbor[worldposition] = new List<TileBase>();
            }
            _neighbor[worldposition].Add(_tilemap.GetTile(new Vector3Int(localposition.x + 1, localposition.y,localposition.z)));
        }

        if (_tilemap.GetTile(new Vector3Int(localposition.x, localposition.y - 1,localposition.z)))
        {
            if (!_neighbor.ContainsKey(worldposition))
            {
                _neighbor[worldposition] = new List<TileBase>();
            }
            _neighbor[worldposition].Add(_tilemap.GetTile(new Vector3Int(localposition.x, localposition.y - 1,localposition.z)));
        }

        if (_tilemap.GetTile(new Vector3Int(localposition.x, localposition.y + 1,localposition.z)))
        {
            if (!_neighbor.ContainsKey(worldposition))
            {
                _neighbor[worldposition] = new List<TileBase>();
            }
            _neighbor[worldposition].Add(_tilemap.GetTile(new Vector3Int(localposition.x, localposition.y + 1,localposition.z)));
        }
    }


    //Return a case with the position
    public Case GetCaseByPosition(Vector3 position)
    {
        return _map[position];
    }
    
    //Get The sprite of a World Position
    public Sprite GetSpriteByPosition(Vector3 position)
    {
        return _mapbyposition[position];
    }
    
    //return TileManger Instance
    public TileManager Instance()
    {
        return _instance;
    }
}

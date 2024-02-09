using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] List<TileData> tilesDatas = new List<TileData>();

    private Dictionary<TileBase, TileData> dataFromTiles = new Dictionary<TileBase, TileData>();
    private Dictionary<Vector3Int, Case> worldToMapInfo = new Dictionary<Vector3Int, Case>();

    private Case[] mapInfo = new Case[225];

    private Vector3Int pos;

    private int lengthLine = 15;

    private void Awake()
    {
        foreach (TileData tileData in tilesDatas)
        {
            foreach (TileBase tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
        // we can now use the tileBase as a way to find the nature of a tile

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                pos.Set(i, j, 0);
                mapInfo[ i * lengthLine + j ] = CreateCase(dataFromTiles[tilemap.GetTile(pos)].id, tilemap.GetTile(pos), tilemap.CellToWorld(pos), i * lengthLine + j);
            }
        }

        InitNeighbor();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int posingrid = worldToMapInfo[tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))].GetPosInGrid();

            FindNeighbourCell(direction.west
                , posingrid).IntroduceYourself();
        }
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
        }

        worldToMapInfo.Add(tilemap.WorldToCell(pos), result);
        return result;
    }

    private void InitNeighbor()
    {
        for (int i = 0; i < 225; i++)
        {
            if (mapInfo[i].IsWalkableByDeath)
            {
                if (i % lengthLine != 0 && mapInfo[i - 1].IsWalkableByDeath)
                {
                    mapInfo[i].AddNeighbor(mapInfo[i - 1]);
                }
                if (i % lengthLine != lengthLine - 1 && mapInfo[i + 1].IsWalkableByDeath)
                {
                    mapInfo[i].AddNeighbor(mapInfo[i + 1]);
                }
                if (i > lengthLine - 1 && mapInfo[i - lengthLine].IsWalkableByDeath)
                {
                    mapInfo[i].AddNeighbor(mapInfo[i - lengthLine]);
                }
                if (i < mapInfo.Length - lengthLine && mapInfo[i + lengthLine].IsWalkableByDeath)
                {
                    mapInfo[i].AddNeighbor(mapInfo[i + lengthLine]);
                }
            }
        }
    }

    public Case FindNeighbourCell(direction dir, int startCellIndex)
    {
        //retourne la case dans la direction indique, ATTENTION, retourne null si la case est hors de la map!!!
        switch (dir) 
        {
            case direction.north:
                //make sure there's a cell above
                if (startCellIndex%14 != 0)
                {
                    return mapInfo[startCellIndex + 1];
                }
                break;

            case direction.south:
                if (startCellIndex % 15 != 0)
                {
                    return mapInfo[startCellIndex - 1];
                }
                break;

            case direction.west:
                if (startCellIndex > 14)
                {
                    return mapInfo[startCellIndex - 15];
                }
                break;

            case direction.est:
                if (startCellIndex < 220)
                {
                    return mapInfo[startCellIndex + 15];
                }
                break;
        }
        return null;
    }
}

public enum direction
{
    north,
    south,
    west,
    est
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    MapData newMap;

    public MapData GenerateMap(Vector2 mapDimsions)
    {
        newMap = new MapData();

        newMap.MapDimensions = mapDimsions;

        newMap.MapTiles = BuildTileBase();

        return newMap;
    }

    List<MapTileData> BuildTileBase()
    {
        List<MapTileData> mapTiles = new List<MapTileData>();

        int tilesCreated = 1;


        for (int currRow = 0; currRow < newMap.MapDimensions.y; currRow++)
        {
            for (int rowPos = 0; rowPos < newMap.MapDimensions.x; rowPos++)
            {
                mapTiles.Add(new MapTileData
                {
                    GridPos = new Vector2(rowPos, currRow),
                    TileID = tilesCreated
                });

                tilesCreated++;

            }
        }

        return mapTiles;
    }
}

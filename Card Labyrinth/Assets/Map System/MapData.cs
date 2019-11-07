using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public List<MapTileData> MapTiles { get; set; }
    public Vector2 MapDimensions { get; set; }

    public MapData()
    {
        MapTiles = new List<MapTileData>();
    }
}

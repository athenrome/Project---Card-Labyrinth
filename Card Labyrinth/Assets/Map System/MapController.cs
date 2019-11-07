using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    TextAsset testData;

    [SerializeField]
    Transform mapTilesContainer;

    public Dictionary<Vector2, MapTile> tileGrid;

    MapData map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void StartMap()
    {

        map = ReadMapCSV(testData);
        BuildMap();

    }

    void BuildMap()
    {

        tileGrid = new Dictionary<Vector2, MapTile>();


        foreach (MapTileData tileData in map.MapTiles)
        {
            MapTile tile = ObjectPool.RetrieveProp("MapTile").GetComponent<MapTile>();//Create a new Tile
            tile.tileData = tileData;

            tile.transform.parent = mapTilesContainer;
            tile.name = $"MapTile X:{tile.tileData.GridPos.x} Y:{tile.tileData.GridPos.y}";

            tile.transform.position = new Vector3
            {
                x = tile.tileData.GridPos.x,
                y = 0,
                z = tile.tileData.GridPos.y
            };

            tileGrid.Add(tile.tileData.GridPos, tile);

        switch (tile.tileData.TileType)
        {
            case "0"://Free
                tile.tileBase.GetComponent<MeshRenderer>().material.color = Color.white;
                break;

            case "1"://Wall
                tile.tileBase.GetComponent<MeshRenderer>().material.color = Color.black;
                break;

            case "2"://Spawn
                tile.tileBase.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;

            case "3"://Exit
                tile.tileBase.GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;

            default:
                tile.tileBase.GetComponent<MeshRenderer>().material.color = Color.red;
                Debug.LogError($"Unable to set: {tile.tileData.TileType}");
                break;

        }
    }

    }

    MapData ReadMapCSV(TextAsset mapData)
    {
        MapData data = new MapData();

        List<string> mazeRows = mapData.text.Split(Environment.NewLine.ToCharArray()).Where(row => String.IsNullOrWhiteSpace(row) == false).ToList();

        int tilesLoaded = 0;

        for (int currRow = 0; currRow < mazeRows.Count; currRow++)
        {
            List<string> rowValues = mazeRows[currRow].Split(',').ToList();

            for (int rowPos = 0; rowPos < rowValues.Count; rowPos++)
            {
                MapTileData tileData = new MapTileData
                {
                    GridPos = new Vector2
                    { x = rowPos,
                        y = currRow
                    },
                    TileID = tilesLoaded,
                    TileType = rowValues[rowPos]
                };

                data.MapTiles.Add(tileData);
            }
        }

        return data;

    }
}

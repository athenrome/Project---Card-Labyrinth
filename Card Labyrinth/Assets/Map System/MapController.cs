using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
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



    public void StartMap(MapData newMap)
    {
        map = newMap;

        tileGrid = new Dictionary<Vector2, MapTile>();
        Transform gridParent = new GameObject().transform;
        gridParent.name = "Tile Grid";
        gridParent.parent = this.transform;

        foreach (MapTileData tileData in map.MapTiles)
        {
            MapTile newTile = ObjectPool.RetrieveProp("MapTile").GetComponent<MapTile>();//Create a new Tile
            newTile.transform.position = new Vector3(tileData.GridPos.x, 0, tileData.GridPos.y);
            newTile.transform.parent = gridParent.transform;
            newTile.tileData = tileData;
            newTile.name = $"MapTile X:{tileData.GridPos.x} Y:{tileData.GridPos.y}";
            tileGrid.Add(tileData.GridPos, newTile);

        }
    }
}

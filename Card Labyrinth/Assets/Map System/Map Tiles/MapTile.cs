using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public MapTileData tileData;

    public GameObject tileBase;

    public Transform centrePoint;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click.");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right click.");

        }
    }
}

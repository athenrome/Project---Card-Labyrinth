using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerController
{
    public static CameraController playerCam;

    public static SelectableObject selectedObj;

    public static Vector2 playerPos;

    public static void SetupPlayer()
    {
        playerCam = GameObject.FindObjectOfType<CameraController>();
    }

    public static void PlayerUpdate()
    {
        HandlePlayerInputs();

        if(Input.GetKey(KeyCode.LeftAlt) == true && Input.GetMouseButtonDown(0) == true)
        {
            RaycastHit hitPoint;

            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint);
            MapTile hitTile = hitPoint.collider.GetComponent<MapTile>();

            hitTile.tileBase.GetComponent<MeshRenderer>().material.color = Color.yellow;


            ObjectPool.RetrieveProp("Unit").transform.position = hitTile.centrePoint.position;
        }
    }

    public static void SelectObject(SelectableObject newSelection)
    {
        selectedObj = newSelection;
    }

    public static void DeselectObject()
    {
        selectedObj = null;
    }

    public static void MovePlayer(Vector2 targetTile)
    {

    }

    static void HandlePlayerInputs()
    {

    }
}

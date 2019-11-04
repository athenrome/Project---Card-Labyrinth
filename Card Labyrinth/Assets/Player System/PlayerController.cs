using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerController
{
    static List<Unit> selectedUnits = new List<Unit>();

    public static CameraController playerCam;

    public static void SetupPlayer()
    {
        playerCam = GameObject.FindObjectOfType<CameraController>();
    }

    public static void PlayerUpdate()
    {
        HandlePlayerInputs();

        if (Input.GetMouseButtonDown(1) == true)
        {
            RaycastHit hitPoint;

            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint);

            Vector3 moveClickPos = hitPoint.point;

            if (selectedUnits.Count == 1)
            {
                selectedUnits[0].SetMoveTarget(moveClickPos);
            }
            else
            {
                ResolveGroupMovement(moveClickPos);
            }
        }

        if(Input.GetKey(KeyCode.LeftAlt) == true && Input.GetMouseButtonDown(0) == true)
        {
            RaycastHit hitPoint;

            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitPoint);
            MapTile hitTile = hitPoint.collider.GetComponent<MapTile>();

            hitTile.tileBase.GetComponent<MeshRenderer>().material.color = Color.yellow;


            ObjectPool.RetrieveProp("Unit").transform.position = hitTile.centrePoint.position;
        }
    }

    static void ResolveGroupMovement(Vector3 startPoint)
    {

    }

    public static void SelectObject(SelectableObject selectedObj)
    {
        if(selectedObj.GetType() == typeof(Unit))
        {
            selectedUnits.Add((Unit)selectedObj);
        }
    }

    public static void DeselectObject(SelectableObject selectedObj)
    {
        if (selectedObj.GetType() == typeof(Unit))
        {
            selectedUnits.Remove((Unit)selectedObj);
        }
    }

    static void HandlePlayerInputs()
    {
        if (InputController.CheckInputEvent("DeselectAll") == true)
        {
            foreach (Unit unit in selectedUnits)
            {
                unit.OnDeselect();
            }

            selectedUnits = new List<Unit>();

        }

    }
}

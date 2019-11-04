using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float panSpeed;

    [SerializeField]
    float zoomSpeed;

    [SerializeField]
    Vector3 cameraOffset;

    [SerializeField]
    float minZoom;

    [SerializeField]
    float maxZoom;

    Transform floorPos;//OBJ that appears in the centre of the camera view

    private void Awake()
    {
        floorPos = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        floorPos.GetComponent<MeshRenderer>().material.color = Color.black;
        floorPos.GetComponent<SphereCollider>().enabled = false;
        floorPos.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PanUpdate();
        ZoomUpdate();
        RotateUpdate();

        RaycastHit hitPoint;

        Physics.Raycast(new Ray(this.transform.position, this.transform.forward), out hitPoint);
        floorPos.position = hitPoint.point;
    }

    void PanUpdate()
    {
        Vector3 panVector = new Vector3();

        //Forward
        if(InputController.CheckInputEvent("CameraForward") == true)
        {
            panVector.z += 1;
        }

        //Back
        if (InputController.CheckInputEvent("CameraBack") == true)
        {
            panVector.z -= 1;
        }

        //Left
        if (InputController.CheckInputEvent("CameraLeft") == true)
        {
            panVector.x -= 1;
        }

        //Right
        if (InputController.CheckInputEvent("CameraRight") == true)
        {
            panVector.x += 1;
        }

        this.transform.position += panVector * panSpeed * Time.deltaTime;

    }

    void ZoomUpdate()
    {
        float distance = Vector3.Distance(this.transform.position, floorPos.position);

        //Zoom In
        if (distance > minZoom)
        {
            this.transform.position += transform.forward * zoomSpeed * Input.mouseScrollDelta.y * Time.deltaTime;
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            this.transform.position += transform.forward * zoomSpeed * Input.mouseScrollDelta.y * Time.deltaTime;
        }

        //Zoom Out
        if (distance < maxZoom)

        Debug.Log($"{distance} - {Input.mouseScrollDelta.y}");


    }

    void RotateUpdate()
    {
        if(InputController.CheckInputEvent("CameraRotateLeft") == true)
        {
            transform.RotateAround(floorPos.position, Vector3.down, 20 * Time.deltaTime);
        }

        if (InputController.CheckInputEvent("CameraRotateRight") == true)
        {
            transform.RotateAround(floorPos.position, Vector3.up, 20 * Time.deltaTime);
        }

    }

    public void LookAtPos(Vector3 targetTile)
    {
        this.transform.position = targetTile + cameraOffset;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    MapController map;

    bool gameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        StartUp();
        PlayerController.SetupPlayer();
        gameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive == true)
        {
            GameLoopUpdate();
        }


    }

    void StartUp()
    {
        LoadControls();

        StartObjectPool();

        MapGenerator mapGen = new MapGenerator();

        map.StartMap();

        FindObjectOfType<CameraController>().LookAtPos(map.tileGrid.Values.Where(t => t.tileData.TileType == "2").FirstOrDefault().transform.position);
    }

    void GameLoopUpdate()
    {
        PlayerController.PlayerUpdate();

    }

    void LoadControls()
    {
        InputController.RegisterInputEvent("CameraFocus", KeyCode.F);

        InputController.RegisterInputEvent("CameraRotate", KeyCode.Mouse1);

        InputController.RegisterInputEvent("CameraForward", KeyCode.W);
        InputController.RegisterInputEvent("CameraLeft", KeyCode.A);
        InputController.RegisterInputEvent("CameraBack", KeyCode.S);
        InputController.RegisterInputEvent("CameraRight", KeyCode.D);
        InputController.RegisterInputEvent("CameraRotateLeft", KeyCode.Q);
        InputController.RegisterInputEvent("CameraRotateRight", KeyCode.E);

        InputController.RegisterInputEvent("Deselect", KeyCode.LeftShift);

        InputController.RegisterInputEvent("DeselectAll", KeyCode.Z);

    }

    void StartObjectPool()
    {


        ObjectPool.InitializePool();

        List<GameObject> objectsToPool = new List<GameObject>();

        Transform objectsContainer = transform.GetChild(0);


        //THIS IS DUMB: For some reason attempting to cycle through all objects and add them to the object pool directly will leave an object behind. It works fine when you add them to a list then to the pool - 20190608

        foreach (Transform child in objectsContainer)
        {
            objectsToPool.Add(child.gameObject);
        }

        foreach (GameObject prop in objectsToPool)
        {
            ObjectPool.StoreProp(prop);
        }

        GameObject.Destroy(objectsContainer.gameObject);


    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolContainer
{
    List<GameObject> storedObjects;

    GameObject originalObj;
    string orginalObjName;

    Transform container;

    public ObjectPoolContainer(GameObject toStore, Transform objectPoolObj)
    {
        container = new GameObject().transform;
        container.parent = objectPoolObj;

        toStore.SetActive(false);//Deactivate Object

        storedObjects = new List<GameObject>();

        originalObj = toStore;
        orginalObjName = toStore.name;

        toStore.transform.parent = container;

        toStore.name = "Original: " + orginalObjName;

        container.name = $"{originalObj.name} : {storedObjects.Count}";

        RestockPool();//Create the first Object that can be returned
    }

    public void StoreObject(GameObject toStore)
    {
        toStore.SetActive(false);//Deactivate Object
        toStore.transform.parent = container;

        storedObjects.Add(toStore);

        container.name = $"{originalObj.name} : {storedObjects.Count}";
    }

    public GameObject GetObject()
    {
        //If we are out of objects then restock the pool
        if(storedObjects.Count == 0)
        {
            RestockPool();
        }

        GameObject toReturn = storedObjects[0];
        storedObjects.Remove(toReturn);

        toReturn.transform.parent = null;
        toReturn.SetActive(true);

        container.name = $"{originalObj.name} : {storedObjects.Count}";

        return toReturn;
    }

    /// <summary>
    /// We are out of objects create and store a new one
    /// </summary>
    void RestockPool()
    {
        //Create and Store a copy of the orginal Object
        GameObject firstObj = GameObject.Instantiate(originalObj);
        firstObj.name = orginalObjName;

        StoreObject(firstObj);
    }
}

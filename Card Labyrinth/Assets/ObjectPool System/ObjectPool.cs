using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPool
{
    static Dictionary<string, ObjectPoolContainer> objectPool;

    static Transform objectPoolObj;

    public static void InitializePool()
    {
        objectPool = new Dictionary<string, ObjectPoolContainer>();

        objectPoolObj = new GameObject("Object Pool").transform;
    }

    public static void StoreProp(GameObject toStore, string nameOveride = null)
    {
        if(nameOveride != null)
        {
            toStore.name = nameOveride;
        }

        if(objectPool.ContainsKey(toStore.name))//A container for a prop already exists
        {
            objectPool[toStore.name].StoreObject(toStore);
        }
        else//Container doesnt exist yet, so create a new container
        {
            objectPool.Add(toStore.name, new ObjectPoolContainer(toStore, objectPoolObj));
        }
    }

    public static GameObject RetrieveProp(string targetObj)
    {
        if(objectPool.ContainsKey(targetObj))
        {
            return objectPool[targetObj].GetObject();
        }
        else
        {
            Debug.Log($"Could not locate object: '{targetObj}' in Pool");
            return null;
        }
    }

    public static bool ContainsObject(string targetObj)
    {
        if (objectPool.ContainsKey(targetObj))
        {
            return true;
        }
        else
        {
            Debug.Log($"Could not locate object: '{targetObj}' in Pool");
            return false;
        }
    }
}

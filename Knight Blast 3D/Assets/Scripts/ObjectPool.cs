using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPool
{
    static private Dictionary<string, KeyValuePair<GameObject, Queue<GameObject>>> poolDictionary = new Dictionary<string, KeyValuePair<GameObject, Queue<GameObject>>>();
    public static void NewPool(string name, GameObject ObjectToPool)
    {
        poolDictionary.Add(name, new KeyValuePair<GameObject, Queue<GameObject>>(ObjectToPool, new Queue<GameObject>()));
    }

    public static void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(poolDictionary[tag].Value.Count == 0)
        {
            AddObjectsToPool(tag, 1, position, rotation);
        }
        GameObject obj = poolDictionary[tag].Value.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

    }
    static void AddObjectsToPool(string tag, int count, Vector3 position, Quaternion rotation)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject obj = Object.Instantiate(poolDictionary[tag].Key);
            obj.SetActive(false);
            poolDictionary[tag].Value.Enqueue(obj);
        }
    }

    public static void ReturnToPool(string tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        poolDictionary[tag].Value.Enqueue(objectToReturn);
    }
}

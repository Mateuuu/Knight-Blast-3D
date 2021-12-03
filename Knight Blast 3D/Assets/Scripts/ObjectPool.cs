using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPool
{
    static private Queue<GameObject> objectsInPool = new Queue<GameObject>();
    static private Dictionary<KeyValuePair<string, GameObject>, Queue<GameObject>> poolDictionary = new Dictionary<KeyValuePair<string, GameObject>,Queue<GameObject>>();
    public static void NewPool(string name, GameObject ObjectToPool)
    {
        
    }

    public static void SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(objectsInPool.Count == 0)
        {
            poolDictionary[[tag]]
            AddObjects(tag, 1, position, rotation);
        }

    }
    static void AddObjects(string tag, int count, Vector3 position, Quaternion rotation)
    {
        for(int i = 0; i < count; i++)
        {
            Object.Instantiate(poolDictionary[].Dequeue());
        }
    }

    public static void ReturnToPool()
    {

    }
}

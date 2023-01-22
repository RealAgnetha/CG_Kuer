using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public int poolSize = 20;
    private Dictionary<string, Queue<GameObject>> objectPools;

    void Start()
    {
        objectPools = new Dictionary<string, Queue<GameObject>>();
        foreach (GameObject obj in pooledObjects)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject newObj = Instantiate(obj);
                newObj.SetActive(false);
                objectPool.Enqueue(newObj);
            }

            objectPools.Add(obj.name, objectPool);
        }
    }

    public GameObject SpawnObject(string objectName, Vector3 position)
    {
        GameObject spawnedObject = objectPools[objectName].Dequeue();
        spawnedObject.transform.position = position;
        spawnedObject.SetActive(true);
        objectPools[objectName].Enqueue(spawnedObject);
        return spawnedObject;
    }

    public void ReturnToPool(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            objectPools[obj.name].Enqueue(obj);
        }
    }
}
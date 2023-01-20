using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    public GameObject newObjPrefab; // new object prefab to spawn when two objects overlap
    public float spawnInterval = 2f;
    public float overlapCheckInterval = 0.5f; // interval to check for overlapping objects
    public float overlapThreshold = 0.5f; // minimum overlap percentage for objects to be replaced

    private Vector2 spawnPosition;
    private int count = 0;

    void Start()
    {
        InvokeRepeating("SpawnObj", 2f, spawnInterval);
        InvokeRepeating("CheckOverlap", overlapCheckInterval, overlapCheckInterval);

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Objects"), LayerMask.NameToLayer("Objects"));
    }

    void SpawnObj()
    {
        float randomX = Random.Range(-2.5f, 2.5f);
        Vector2 spawnPos = new Vector2(randomX, 6);
        GameObject instance = Instantiate(objPrefab, spawnPos, Quaternion.identity);
        instance.name = "Object " + count;
        count++;
    }

    void CheckOverlap()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Object"); 
        for (int i = 0; i < allObjects.Length; i++)
        {
            for (int j = i+1; j < allObjects.Length; j++)
            {
                if(allObjects[i].GetComponent<Collider2D>().bounds.Contains(allObjects[j].transform.position) || allObjects[j].GetComponent<Collider2D>().bounds.Contains(allObjects[i].transform.position))
                {
                    Debug.Log("overlap");
                }
            }
        }
    }


    
}
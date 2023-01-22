using UnityEngine;
using TMPro;

public class ObjSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    public TextMeshProUGUI statusText;

    public float spawnInterval = 2f;
    public float overlapCheckInterval = 0.5f; // interval to check for overlapping objects
    public float overlapThreshold = 0.5f; // minimum overlap percentage for objects to be replaced

    private Vector2 spawnPosition;
    private int count = 0;
    private int mergeCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnObj", 2f, spawnInterval);
        InvokeRepeating("CheckOverlap", overlapCheckInterval, overlapCheckInterval);

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Objects"), LayerMask.NameToLayer("Objects"));
        statusText.text = "Count: " + mergeCount;
    }

    void Update()
    {
        statusText.text = "Count: " + mergeCount * 10;
    }

    void SpawnObj()
    {
        float randomX = Random.Range(-2.5f, 2.5f);
        Vector2 spawnPos = new Vector2(randomX, 6);
        GameObject instance = Instantiate(objPrefab, spawnPos, Quaternion.identity);
        instance.GetComponent<Mergeable>().SetLevel(0);
        instance.name = "Object " + count;
        count++;
    }

    void CheckOverlap()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Object");
        for (int i = 0; i < allObjects.Length; i++)
        {
            for (int j = i + 1; j < allObjects.Length; j++)
            {
                int firstObjectLevel = allObjects[i].GetComponent<Mergeable>().Level;
                int secondObjectLevel = allObjects[j].GetComponent<Mergeable>().Level;
                if (firstObjectLevel != secondObjectLevel)
                {
                    continue;
                }

                if (allObjects[i].GetComponent<Collider2D>().bounds.Contains(allObjects[j].transform.position) ||
                    allObjects[j].GetComponent<Collider2D>().bounds.Contains(allObjects[i].transform.position))
                {
                    Vector2 spawnPos =
                        new Vector2((allObjects[i].transform.position.x + allObjects[j].transform.position.x) / 2,
                            (allObjects[i].transform.position.y + allObjects[j].transform.position.y) / 2);
                    GameObject newInstance = Instantiate(objPrefab, spawnPos, Quaternion.identity);
                    newInstance.GetComponent<Mergeable>().SetLevel(firstObjectLevel+1);

                    newInstance.name = "New Object " + count;
                    count++;
                    Destroy(allObjects[i]);
                    Destroy(allObjects[j]);
                    mergeCount++;
                }
            }
        }
    }
}
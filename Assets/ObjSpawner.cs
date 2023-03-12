using UnityEngine;
using TMPro;

public class ObjSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    public TextMeshProUGUI statusText;
    public bool glitterIsActive = false;
    public bool speedIsIncreased = false;

    public float spawnInterval = 5f;
    public float overlapCheckInterval = 0.5f; // interval to check for overlapping objects

    private Vector2 spawnPosition;
    private int count = 0;
    public int mergeCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnObj", 2f, spawnInterval);
        InvokeRepeating("CheckOverlap", overlapCheckInterval, overlapCheckInterval);

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Objects"), LayerMask.NameToLayer("Objects"));
        statusText.text = "Points: " + mergeCount;
    }

    void Update()
    {
        statusText.text = "Points: " + mergeCount;
    }

    void SpawnObj()
    {
        float randomX = Random.Range(-2.5f, 2.5f);
        Vector2 spawnPos = new Vector2(randomX, 6);
        GameObject instance = Instantiate(objPrefab, spawnPos, Quaternion.identity);
        instance.GetComponent<Mergeable>().SetLevel(0);
        instance.name = "Object " + count;
        count++;
        if (glitterIsActive)
        {
            Debug.Log("Glitter active: " + glitterIsActive);
            instance.GetComponent<ParticleSystem>().Play();
        }
        if (speedIsIncreased)
        {
            spawnInterval /= 2.0f; // decrease the spawn interval by half
            CancelInvoke("SpawnObj");
            InvokeRepeating("SpawnObj", 2f, spawnInterval);
        }
        
    }

    public void ActivateGlitter(bool active)
    {
        Debug.Log("ActivateGlitter: " + active);
        glitterIsActive = active;
    }

    public void IncreaseSpeed(bool active)
    {
        Debug.Log("Speed increased: " + active);
        speedIsIncreased = active;
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
                    newInstance.GetComponent<Mergeable>().SetLevel(firstObjectLevel + 1);
                    if (glitterIsActive)
                    {
                        Debug.Log("Glitter active: " + glitterIsActive);
                        newInstance.GetComponent<ParticleSystem>().Play();
                    }
                    newInstance.name = "New Object " + count;
                    count++;
                    Destroy(allObjects[i]);
                    Destroy(allObjects[j]);

                    // update mergeCount based on the level of the merged objects
                    mergeCount += ((int)Mathf.Pow(10, firstObjectLevel)) * 10;
                }
            }
        }
    }
}
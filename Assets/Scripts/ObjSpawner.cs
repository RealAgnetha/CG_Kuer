using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    public TextMeshProUGUI statusTMP;
    public TextMeshProUGUI countDownTMP;

    public bool glitterIsActive = false;
    public bool speedIsIncreased = false;

    public float spawnInterval = 5f;
    public float overlapCheckInterval = 0.5f; // interval to check for overlapping objects

    private Vector2 spawnPosition;
    private int count = 0;
    public int mergeCount = 0;
    private float spawnTimer;

    void Start()
    {
        InvokeRepeating("SpawnObj", 2f, spawnInterval);
        InvokeRepeating("CheckOverlap", overlapCheckInterval, overlapCheckInterval);

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Objects"), LayerMask.NameToLayer("Objects"));
        statusTMP.text = "Points: " + mergeCount;
        spawnTimer = spawnInterval - 2f;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        statusTMP.text = "Points: " + mergeCount;
        countDownTMP.text = spawnTimer.ToString("0.0") + "s";
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

        spawnTimer = spawnInterval; // reset spawn timer
    }

    public void ActivateGlitter(bool active)
    {
        Debug.Log("ActivateGlitter: " + active);
        glitterIsActive = active;
        mergeCount -= 1000;
    }

    public void IncreaseSpeed(bool active)
    {
        Debug.Log("Speed increased: " + active);
        spawnInterval -= 1.0f;
        CancelInvoke("SpawnObj");
        InvokeRepeating("SpawnObj", 2f, spawnInterval);
        mergeCount -= 100;
        spawnTimer = spawnInterval;
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

                    /*visual effect when merged*/
                    BiggerOnMerge biggerOnMerge = newInstance.AddComponent<BiggerOnMerge>();
                    biggerOnMerge.DoEffect();

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
    
    public void SetGameStateData(int newMergeCount, float newSpawnInterval)
    {
        this.mergeCount = newMergeCount;
        this.spawnInterval = newSpawnInterval;
    }
}
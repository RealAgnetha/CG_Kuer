using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    public float spawnInterval = 2f;

    private Vector2 spawnPosition;
    private int count = 0;

    void Start()
    {
        spawnPosition = new Vector2(0f, 6);
        InvokeRepeating("SpawnObj", 2f, spawnInterval);
    }

    void SpawnObj()
    {
        GameObject instance = Instantiate(objPrefab, spawnPosition, Quaternion.identity);
        instance.name = "Object " + count;
        count++;
    }
}

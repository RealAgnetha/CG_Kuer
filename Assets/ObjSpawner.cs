using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject objPrefab;
    public float spawnInterval = 2f;

    private Vector2 spawnPosition;
    void Start()
    {
        spawnPosition = new Vector2(0f, Screen.height);
        InvokeRepeating("SpawnObj", 0f, spawnInterval);
    }

    void SpawnObj()
    {
        Instantiate(objPrefab, spawnPosition, Quaternion.identity);
    }

}

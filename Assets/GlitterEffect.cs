using UnityEngine;

public class ParticleEffectOnSpawn : MonoBehaviour
{
    public GameObject particleEffect;

    private void Start()
    {
        GameObject newObject = InstantiateObject();
        Instantiate(particleEffect, newObject.transform.position, Quaternion.identity);
    }

    private GameObject InstantiateObject()
    {
        GameObject newObj = new GameObject();
        return newObj;
    }
}
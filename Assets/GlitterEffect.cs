using UnityEngine;

public class ParticleEffectOnSpawn : MonoBehaviour
{
    public GameObject particleEffect;

    private void Start()
    {
        // Replace "InstantiateObject()" with your own object instantiation method
        GameObject newObject = InstantiateObject();

        // Instantiate the particle effect at the same position as the new object
        Instantiate(particleEffect, newObject.transform.position, Quaternion.identity);
    }

    // Example object instantiation method
    private GameObject InstantiateObject()
    {
        // Replace this code with your own object instantiation logic
        GameObject newObj = new GameObject();
        return newObj;
    }
}
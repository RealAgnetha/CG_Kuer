using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed;
    private float stopY;
    private bool stop = false;

    void Start()
    {
        stopY = Random.Range(-4.0f, 2.0f);
    }

    void Update()
    {
        if (!stop && transform.position.y > stopY)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else
        {
            stop = true;
        }
    }
}
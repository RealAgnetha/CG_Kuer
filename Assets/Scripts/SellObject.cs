using UnityEngine;

public class SellObject : MonoBehaviour
{
    public ObjSpawner objSpawner;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null && hit.collider.CompareTag("Object"))
            {
                if (hit.collider.transform.position.y < -4f &&
                    hit.collider.GetComponent<Renderer>().material.color != Color.gray)
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.gray;
                }
            }
        }
    }

    void OnMouseUp()
    {
        if (transform.position.y < -4f)
        {
            if (GetComponent<Renderer>().material.color == Color.gray)
            {
                objSpawner.mergeCount += 10;
                Destroy(gameObject);
            }
        }
    }
}

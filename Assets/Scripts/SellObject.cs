using UnityEngine;

public class SellObject : MonoBehaviour
{
    private bool isBeingDragged = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (!isBeingDragged)
        {
            // Set the flag to true and store the offset between the object's position and the mouse position
            isBeingDragged = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if (isBeingDragged)
        {
            // Set the flag to false
            isBeingDragged = false;
        }
    }

    private void Update()
    {
        if (isBeingDragged)
        {
            // Move the object according to the mouse position and the offset
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }
    }
}

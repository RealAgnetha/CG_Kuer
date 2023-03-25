using UnityEngine;

public class TextScroller : MonoBehaviour
{
    public float scrollSpeed = 100f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.position = new Vector3(-(2*rectTransform.rect.width), rectTransform.position.y, rectTransform.position.z);
    }

    void Update()
    {
        rectTransform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        if (rectTransform.position.x >= Screen.width)
        {
            rectTransform.position = new Vector3(-rectTransform.rect.width, rectTransform.position.y, rectTransform.position.z);
        }
    }
}
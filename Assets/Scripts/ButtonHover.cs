using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float hoverScale = 1.2f; 
    private Vector3 originalScale; 
    private bool isHovering = false; 
    private Button button; 

    void Start()
    {
        button = GetComponent<Button>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (button.isActiveAndEnabled && isHovering)
        {
            transform.localScale = originalScale * hoverScale;
        }
        else
        {
            transform.localScale = originalScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
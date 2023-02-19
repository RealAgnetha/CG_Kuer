using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public ObjSpawner objSpawner;
    public GameObject popupMenu;
    private Image bgImage;

    private void Start()
    {
        bgImage = popupMenu.GetComponent<Image>();
    }

    private void Update()
    {
        UnityEngine.Debug.Log("Merge Count: " + objSpawner.mergeCount);
        if (objSpawner.mergeCount >= 100)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
        if (Input.GetMouseButtonDown(0) && popupMenu.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(
                popupMenu.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            popupMenu.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        popupMenu.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        popupMenu.SetActive(false);
    }
}
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
        if (objSpawner.mergeCount >= 100)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void ActivateGlitter()
    {
        Debug.Log("activate glitter");
        objSpawner.ActivateGlitter(true);
        popupMenu.SetActive(false);

    }

    public void OnButtonClick()
    {
        popupMenu.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        Debug.Log("Closed on close button ");
        popupMenu.SetActive(false);
    }
}
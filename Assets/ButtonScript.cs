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
        if (button.name == "CloseBtn")
        {
                 button.interactable = true;
        }
        else if (objSpawner.mergeCount >= 100) // Change the merge count condition to 1000
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
        
        if (button.name == "GlitterBtn" && objSpawner.mergeCount < 1000)
        {
            button.interactable = false;
        }
        
    }

    public void ActivateGlitter()
    {
        Debug.Log("activate glitter");
        objSpawner.ActivateGlitter(true);
        button.interactable = false;
        button.GetComponent<Image>().color = Color.gray;    }

    public void IncreaseSpeed()
    {
        Debug.Log("increase speed");
        objSpawner.IncreaseSpeed(true);
        button.interactable = false;
        button.GetComponent<Image>().color = Color.gray;
    }
    
    public void OnButtonClick()
    {
        popupMenu.SetActive(true);
    }

    public void ClosePopup()
    {
        Debug.Log("Closed on close button ");
        popupMenu.SetActive(false);
    }
}
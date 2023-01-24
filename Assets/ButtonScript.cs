using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public ObjSpawner objSpawner;

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
    }


    public void OnSellButtonClick()
    {
        objSpawner.spawnInterval -= 0.5f;
        button.interactable = false;
    }

}
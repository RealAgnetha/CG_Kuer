using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Button button;
    public ObjSpawner objSpawner;
    public GameObject popupMenu;
    private Image bgImage;
    private bool isPaused = false;
    
    private void Start()
    {
        bgImage = popupMenu.GetComponent<Image>();
    }

    private void Update()
    {
        if (button.name == "CloseBtn" || button.name == "HomeBtn" || button.name == "PauseBtn" || button.name == "Cart" ) 
        {
            button.interactable = true;
        }
        else if (objSpawner.mergeCount >= 100) 
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
        button.GetComponent<Image>().color = Color.gray;
    }

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

    public void NextLevel()
    {
        Debug.Log("Next level started");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ResumeGame();
    }
    
    public void PreviousLevel()
    {
        Debug.Log("Next level started");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        ResumeGame();
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void PausePlay()
    {
        Debug.Log("Game Paused/Resumed");
        if (isPaused) {
            ResumeGame();
            isPaused = false;
            Debug.Log("Paused:" + isPaused);
        }
        else
        {
            PauseGame();
            isPaused = true;
            Debug.Log("Paused:" + isPaused);
        }
    }
    
    public void GoHome()
    {
        Debug.Log("Homebutton pressed");
        SceneManager.LoadScene(0);
        ResumeGame();
    }
}
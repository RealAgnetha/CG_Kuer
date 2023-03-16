using TMPro;
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
    int speedButtonClickCount = 0;

    private void Start()
    {
        bgImage = popupMenu.GetComponent<Image>();
    }

    private void Update()
    {
        if (button.name == "SellBtn")
        {
            if (objSpawner.mergeCount < 100)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }

        if (button.name == "GlitterBtn")
        {
            if (objSpawner.mergeCount < 1000)
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }

        if (button.name == "SpeedBtn")
        {
            TMP_Text speedAmount = GameObject.Find("SpeedAmount").GetComponent<TMP_Text>();
            if (objSpawner.mergeCount < (int.Parse(speedAmount.text)))
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
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
        TMP_Text speedLabel = GameObject.Find("SpeedLabel").GetComponent<TMP_Text>();
        TMP_Text speedAmount = GameObject.Find("SpeedAmount").GetComponent<TMP_Text>();

        if (CheckSufficientPoints(int.Parse(speedAmount.text)))
        {
            speedButtonClickCount++;
            if (speedButtonClickCount == 3)
            {
                button.interactable = false;
                button.GetComponent<Image>().color = Color.gray;
                speedLabel.text = "Increase Speed";
                speedAmount.text = "0";
                speedAmount.enabled = false;
            }

            if (speedButtonClickCount <= 2)
            {
                button.interactable = true;
                objSpawner.IncreaseSpeed(true);
                speedLabel.text = "Increase Speed " + (speedButtonClickCount + 1).ToString();
                int newAmount = ((speedButtonClickCount + 1) * 100);
                speedAmount.text = newAmount.ToString();
                objSpawner.mergeCount -=
                    ((speedButtonClickCount - 1) * 100); // subtract 100 from mergeCount for each speed increase
            }
        }
        else
        {
            button.interactable = false;
        }
    }

    private bool CheckSufficientPoints(int neededPoints)
    {
        return objSpawner.mergeCount >= neededPoints;
    }

    public void OpenPopup()
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

    void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void PausePlay()
    {
        Debug.Log("Game Paused/Resumed");
        if (isPaused)
        {
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
}
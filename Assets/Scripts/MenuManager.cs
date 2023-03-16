using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ResumeOldGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    
    public void StartNewGame()
    {
        PlayerPrefs.DeleteKey("mergeCount");
        PlayerPrefs.DeleteKey("spawnInterval");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
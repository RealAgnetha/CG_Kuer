using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public ObjSpawner spawner;
    public ButtonScript buttonScript;
    
    void OnEnable()
    {
        if (PlayerPrefs.HasKey("mergeCount") && PlayerPrefs.HasKey("spawnInterval"))
        {
            // Load and set the game state data
            int mergeCount = PlayerPrefs.GetInt("mergeCount");
            float spawnInterval = PlayerPrefs.GetFloat("spawnInterval");
            bool glitterIsActive = PlayerPrefs.GetInt("glitterIsActive") == 1 ? true : false;
            spawner.glitterIsActive = glitterIsActive;
            spawner.SetGameStateData(mergeCount, spawnInterval);
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("mergeCount", spawner.mergeCount);
        PlayerPrefs.SetFloat("spawnInterval", spawner.spawnInterval);
        PlayerPrefs.SetInt("glitterIsActive", spawner.glitterIsActive ? 1 : 0);
    }

    public void GoHome()
    {
        Debug.Log("Home button pressed");
        // Save the game state data before going to home screen
        PlayerPrefs.SetInt("mergeCount", spawner.mergeCount);
        PlayerPrefs.SetFloat("spawnInterval", spawner.spawnInterval);

        SceneManager.LoadScene(0);
        buttonScript.ResumeGame();
    }
}
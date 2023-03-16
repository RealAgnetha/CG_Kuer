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
            spawner.SetGameStateData(mergeCount, spawnInterval);
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("mergeCount", spawner.mergeCount);
        PlayerPrefs.SetFloat("spawnInterval", spawner.spawnInterval);
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
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    // Reference to the game script that controls the game
    public ObjSpawner spawner;

    void OnEnable()
    {
        // Check if the game state data exists in PlayerPrefs
        if (PlayerPrefs.HasKey("mergeCount") && PlayerPrefs.HasKey("spawnInterval"))
        {
            // Load the game state data
            int mergeCount = PlayerPrefs.GetInt("mergeCount");
            float spawnInterval = PlayerPrefs.GetFloat("spawnInterval");

            // Set the game state data in the game script
            spawner.SetGameStateData(mergeCount, spawnInterval);
        }
    }

    void OnDisable()
    {
        // Save the game state data when the script is disabled
        PlayerPrefs.SetInt("mergeCount", spawner.mergeCount);
        PlayerPrefs.SetFloat("spawnInterval", spawner.spawnInterval);
    }

    public void GoHome()
    {
        Debug.Log("Home button pressed");

        // Save the game state data
        PlayerPrefs.SetInt("mergeCount", spawner.mergeCount);
        PlayerPrefs.SetFloat("spawnInterval", spawner.spawnInterval);

        // Load scene 0
        SceneManager.LoadScene(0);
    }
}
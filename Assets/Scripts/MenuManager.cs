using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject audioSettings;
    public Button startNewBtn;
    public Button resumeBtn;
    public Button exitBtn;
    public TextMeshProUGUI currentlyPlayingTMP;
    
    void Update()
    {
        if (currentlyPlayingTMP != null && AudioListener.pause == false && AudioListener.volume != 0)
        {
            AudioSource[] sources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource source in sources)
            {
                if (source.isPlaying)
                {
                    currentlyPlayingTMP.text = source.clip.name;
                }
            }
        }
    }

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
    
    public void OpenAudio()
    {
        audioSettings.SetActive(true);
        startNewBtn.interactable = false;
        resumeBtn.interactable = false;
        exitBtn.interactable = false;
    }
    
    public void CloseAudio()
    {
        startNewBtn.interactable = true;
        resumeBtn.interactable = true;
        exitBtn.interactable = true;
        audioSettings.SetActive(false);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
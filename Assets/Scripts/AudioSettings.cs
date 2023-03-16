using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    
    private const string SoundEnabledKey = "SoundEnabled";

   
    public void SoundOff()
    {
        audioSource.volume = 0;
        AudioListener.pause = true;
        PlayerPrefs.SetInt(SoundEnabledKey, 0);
    }

    public void SoundOn()
    {
        audioSource.volume = 1;
        AudioListener.pause = false;
        PlayerPrefs.SetInt(SoundEnabledKey, 1);
    }

    public static bool SoundEnabled
    {
        get { return PlayerPrefs.GetInt(SoundEnabledKey, 1) == 1; }
        set { PlayerPrefs.SetInt(SoundEnabledKey, value ? 1 : 0); }
    }

    public void ToggleSound()
    {
        SoundEnabled = !SoundEnabled;
        SetSoundState();
    }

    private void SetSoundState()
    {
        if (SoundEnabled)
        {
            SoundOn();
            Debug.Log("Sound enabled");
        }
        else
        {
            SoundOff();
            Debug.Log("Sound disabled");
        }
        PlayerPrefs.SetInt(SoundEnabledKey, SoundEnabled ? 1 : 0);

    }
    
    public void SetVolume(float volume)
    {
audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20); 
        Debug.Log(volume);
    }

}
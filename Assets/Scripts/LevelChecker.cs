using UnityEngine;

public class LevelChecker : MonoBehaviour
{
    public GameObject levelCompletePopup;

    private void Update()
    {
        Mergeable[] mergeables = FindObjectsOfType<Mergeable>();

        foreach (Mergeable mergeable in mergeables)
        {
            int lastLevelIndex = mergeable.levelSprites.Count - 1;
            if (mergeable.Level == lastLevelIndex)
            {
                levelCompletePopup.SetActive(true);
                Time.timeScale = 0;
                
                Debug.Log("Last level reached by " + mergeable.gameObject.name);
            }
        }
    }
}
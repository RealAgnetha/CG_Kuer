using UnityEngine;

public class BiggerOnMerge : MonoBehaviour
{
    public float maxScaleMultiplier = 1.1f;
    public float scaleChangeDuration = 1f;
    private float scaleChangeStartTime;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        float elapsedTime = Time.time - scaleChangeStartTime;

        if (elapsedTime < scaleChangeDuration / 2)
        {
            // Increase in size
            float timeRatio = elapsedTime / (scaleChangeDuration / 2);
            transform.localScale = initialScale * Mathf.Lerp(1f, maxScaleMultiplier, timeRatio);
        }
        else if (elapsedTime < scaleChangeDuration)
        {
            // Decrease in size -> pulse effect
            float timeRatio = (elapsedTime - scaleChangeDuration / 2) / (scaleChangeDuration / 2);
            transform.localScale = initialScale * Mathf.Lerp(maxScaleMultiplier, 1f, timeRatio);
        }
        else
        {
            transform.localScale = initialScale;
            Destroy(this);
        }
    }

    public void DoEffect()
    {
        scaleChangeStartTime = Time.time;
    }
}
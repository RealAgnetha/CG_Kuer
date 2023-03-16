using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerOnMerge : MonoBehaviour
{
    public float maxScaleMultiplier = 1.1f;
    public float scaleChangeDuration = 2f;
    private float scaleChangeStartTime;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        if (Time.time - scaleChangeStartTime < scaleChangeDuration)
        {
            float timeRatio = (Time.time - scaleChangeStartTime) / scaleChangeDuration;
            transform.localScale = initialScale * Mathf.Lerp(1f, maxScaleMultiplier, timeRatio);
        }
        else
        {
            transform.localScale = initialScale * maxScaleMultiplier;
            Destroy(this);
        }
    }

    public void StartScaling()
    {
        scaleChangeStartTime = Time.time;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mergeable : MonoBehaviour
{
    public int Level { get; private set; }
    [SerializeField] private List<Sprite> levelSprites;

    public void SetLevel(int level)
    {
        Level = level;
        if (Level <= levelSprites.Count)
        {
            GetComponent<SpriteRenderer>().sprite = levelSprites[Level];
        }
    }
}
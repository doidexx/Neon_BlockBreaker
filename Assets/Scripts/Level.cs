using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Serialized for debugging
    [SerializeField]
    int breakableBlocks;

    [Range(0f, 1f)] [SerializeField] float gameTime;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        Time.timeScale = gameTime;
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void SubstractBreakableBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            levelManager.LoadNextLevel();
        }
    }
}

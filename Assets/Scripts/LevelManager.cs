using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelPopulator levelPopulator;
    [SerializeField] Transform blockHolder;
    [SerializeField] BallBehavior ball;
    public int lvl;
    public int score;
    
    private int blocksInLvl;

    public void increaseScore(int value) => score += value;

    public void IncreaseBlockAmount() => blocksInLvl++;

    public void DecreaseBlockAmount() 
    {
        blocksInLvl--;
        if (blocksInLvl == 0) LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        ball.ResetBall();
        lvl++;
        CleanBlockGrid();
        levelPopulator.PopulateGrid();
    }

    private void CleanBlockGrid()
    {
        foreach (Transform block in blockHolder)
        {
            Destroy(block.gameObject);
        }
    }
}

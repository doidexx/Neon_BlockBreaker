using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    One,
    Two,
    Tree,
    Unbreakable,
    None
}

public class LevelPopulator : MonoBehaviour
{
    [SerializeField] LevelManager manager;
    [SerializeField] LevelProgression progression;
    [Header("Block Settings")]
    [SerializeField] BlockBehavior[] blocks;
    [SerializeField] float blockWidth;
    [SerializeField] float blockHeight;
    [Header("Grid Settings")]
    [SerializeField] Transform blockHolder;
    [SerializeField] int gridSize;
    [SerializeField] int MAX_GRID_WIDTH;
    [SerializeField] int MAX_GRID_HEIGHT;
    [SerializeField] float GRID_START_X;
    [SerializeField] float GRID_START_Y;

    private int basePercent;
    private int nonePercent;
    private int unbreakablePercent;
    private int treePercent;
    private int twoPercent;
    private List<int> unbreakables;

    private void Start()
    {
        progression.PopulateDictionary();
        PopulateGrid();
    }

    public void PopulateGrid()
    {
        unbreakables = new List<int>();
        GetPercentages();
        for (int i = 0; i < gridSize; i++)
        {
            float percentage = Random.Range(0, basePercent + 1);
            CheckBlock(percentage, i);
        }
    }

    private void GetPercentages()
    {
        basePercent = progression.basePercent;
        nonePercent = progression.GetPercent(manager.lvl, BlockType.None);
        unbreakablePercent = progression.GetPercent(manager.lvl, BlockType.Unbreakable);
        treePercent = progression.GetPercent(manager.lvl, BlockType.Tree);
        twoPercent = progression.GetPercent(manager.lvl, BlockType.Two);
    }

    private void CheckBlock(float percentage, int position)
    {
        if (percentage <= nonePercent)
            SpawnBlock(BlockType.None, position);
        else if (percentage <= unbreakablePercent + nonePercent)
            PreventUnbreakableCage(position);
        else if (percentage <= treePercent + unbreakablePercent + nonePercent)
            SpawnBlock(BlockType.Tree, position);
        else if (percentage <= twoPercent + treePercent + unbreakablePercent + nonePercent)
            SpawnBlock(BlockType.Two, position);
        else
            SpawnBlock(BlockType.One, position);
    }

    private void PreventUnbreakableCage(int position)
    {
        for(int i = 0; i < unbreakables.Count; i++)
        {
            if (position == unbreakables[i] + 38)
            {
                float percentage = Random.Range(0, basePercent + 1);
                CheckBlock(percentage, position);
                return;
            }
        }
        unbreakables.Add(position);
        SpawnBlock(BlockType.Unbreakable, position);
    }

    private void SpawnBlock(BlockType lvl, int position)
    {
        foreach(var block in blocks)
        {
            if (lvl == BlockType.None || block.level != lvl) continue;
            if (lvl != BlockType.Unbreakable) manager.IncreaseBlockAmount();
            var newBlock = Instantiate(block.gameObject, Vector2.zero, Quaternion.identity, blockHolder);
            newBlock.transform.localPosition = GetGridPosition(position);
            return;
        }
    }

    private Vector2 GetGridPosition(int position)
    {
        var newX = GRID_START_X + (blockWidth * position % MAX_GRID_WIDTH);
        var newY = GRID_START_Y - (blockHeight + position / MAX_GRID_WIDTH % MAX_GRID_HEIGHT);
        return new Vector2(newX, newY);
    }
}

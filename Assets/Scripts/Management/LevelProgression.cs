using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "New Progression")]
public class LevelProgression : ScriptableObject
{
    public int lastScore;
    public int basePercent;
    public Progression[] progression;
    public Dictionary<int, Dictionary<BlockType, int>> progressionDic;

    public void PopulateDictionary()
    {
        progressionDic = new Dictionary<int, Dictionary<BlockType, int>>();
        for(int i = 0; i < progression.Length; i++)
        {
            var blockDic = new Dictionary<BlockType, int>();

            blockDic[BlockType.None] = progression[i].nonePercent;
            blockDic[BlockType.Unbreakable] = progression[i].unbreakablePercent;
            blockDic[BlockType.Tree] = progression[i].treePercent;
            blockDic[BlockType.Two] = progression[i].twoPercent;
            
            progressionDic[i + 1] = blockDic;
        }
    }

    public int GetPercent(int _lvl, BlockType blockLvl)
    {
        if (_lvl >= progression.Length)
            _lvl = progression.Length - 1;
        else if (_lvl <= 0)
            _lvl = 1;
        return progressionDic[_lvl][blockLvl];
    }

    public float GetBallSpeed(int _lvl)
    {
        return progression[_lvl - 1].ballSpeed;
    }
}

[System.Serializable]
public class Progression
{
    public float ballSpeed;
    public int nonePercent;
    public int unbreakablePercent;
    public int treePercent;
    public int twoPercent;
}

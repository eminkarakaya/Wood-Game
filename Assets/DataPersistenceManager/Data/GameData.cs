using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int moveLevel, attackLevel, bagLevel;
    public List<bool> farmTreeIsUnLocked = new List<bool>();
    public int farmIndex;
    public int workerCount;
    public int level;
    public int axIndex;
    public GameData()
    {
        axIndex = 0;
        level = 0;
        workerCount = 0;
        moveLevel = 0;
        attackLevel = 0;
        bagLevel = 0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int moveLevel, attackLevel, bagLevel;
    public List<bool> farmTreeIsUnLocked = new List<bool>();
    public int farmIndex;
    public GameData()
    {
        
        moveLevel = 0;
        attackLevel = 0;
        bagLevel = 0;
    }
}
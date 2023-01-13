using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : Singleton<FarmManager>,IDataPersistence
{
    [SerializeField] private List<FarmTree> farmTrees;
    [SerializeField] private List<Transform> farmPlaces;
    public void LoadData(GameData data)
    {
        if (data.farmTreeIsUnLocked.Count == 0)
            return;
        for (int i = 0; i < data.farmTreeIsUnLocked.Count; i++)
        {
            farmTrees[i].isUnLocked = data.farmTreeIsUnLocked[i];
            if (farmTrees[i].isUnLocked)
            {
                farmTrees[i].RestartAnim();
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.farmTreeIsUnLocked.Clear();
        for (int i = 0; i < farmTrees.Count; i++)
        {
            data.farmTreeIsUnLocked.Add(farmTrees[i].isUnLocked);
        }
    }
    public void UnlockTree(int index)
    {
        
        farmTrees[index].isUnLocked = true;
        farmTrees[index].RestartAnim();
    }
}

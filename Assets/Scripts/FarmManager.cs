using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : Singleton<FarmManager>,IDataPersistence
{
    public Transform baseTransform;
    [SerializeField] private List<FarmTree> farmTrees;
    [SerializeField] private List<Transform> farmPlaces;
    [SerializeField] private int workerCount;
    [SerializeField] private Transform spawnPos;
    public DropGold dropGold;
    public DropFromBagDestroy drop;
    public FillAmountPlace fillAmountPlace;
    private void Awake()
    {
        fillAmountPlace.onFill += WorkerCount;
    }
    private void OnDisable()
    {
        fillAmountPlace.onFill -= WorkerCount;
        
    }
    private void OnEnable()
    {
        baseTransform = GameObject.FindGameObjectWithTag("Base").transform;
    }
    public void LoadData(GameData data)
    {
        workerCount = data.workerCount;
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
        for (int i = 0; i < workerCount; i++)
        {
            fillAmountPlace.Trigger();
        }
    }
    private void WorkerCount()
    {
        workerCount++;
    }

    public void SaveData(GameData data)
    {
        data.workerCount = workerCount;
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
    public Vector3 GetFarmPlace(int index)
    {
        return farmPlaces[index].position;
    }
    public FarmTree GetFarmTree(int index)
    {
        return farmTrees[index];
    }
}

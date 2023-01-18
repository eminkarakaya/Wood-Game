using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FarmManager : Singleton<FarmManager>,IDataPersistence
{
    public int max;
    public TextMeshProUGUI workerText;
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
        workerText = fillAmountPlace.transform.GetChild(7).GetComponent<TextMeshProUGUI>();
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
       
        Debug.Log(data.farmTreeIsUnLocked.Count);
        for (int i = 0; i < data.farmTreeIsUnLocked.Count; i++)
        {
            farmTrees[i].isUnLocked = data.farmTreeIsUnLocked[i];
            if (farmTrees[i].isUnLocked)
            {
                farmTrees[i].RestartAnim();
            }
        }
        workerCount = data.worketCount;
        for (int i = 0; i < workerCount; i++)
        {
            fillAmountPlace.Trigger();
        }
        SetWorkerCount(workerCount);
    }
    public void SaveData(GameData data)
    {
        data.farmTreeIsUnLocked.Clear();
        data.worketCount = workerCount;
        
        for (int i = 0; i < farmTrees.Count; i++)
        {
            data.farmTreeIsUnLocked.Add(farmTrees[i].isUnLocked);
            Debug.Log(data.farmTreeIsUnLocked[i]);
        }
    }
    private void WorkerCount()
    {
        workerCount++;
    }
    public int GetWorkerCount()
    {
        return workerCount;
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
    public void SetWorkerCount(int value)
    {
        workerCount = value;
        workerText.text = workerCount.ToString() + "/" + max;
    }
    public bool CheckFull()
    {
        if(workerCount >= max)
        {
            return true;
        }
        return false;
    }
}

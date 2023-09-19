using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FarmManager : MonoBehaviour
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
    public static FarmManager Instance;
    const string FARM_TREE_KEY = "FarmTree";
    [SerializeField] private GameObject aiPrefab;
    [SerializeField] private Transform spawnTransform;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(this.gameObject);

        // workerText = fillAmountPlace.transform.GetChild(7).GetComponent<TextMeshProUGUI>();

    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("workerCount",workerCount);
        for (int i = 0; i < farmTrees.Count; i++)
        {
            if(farmTrees[i].isUnLocked)
            {
                PlayerPrefs.SetInt(FARM_TREE_KEY + i,1);
                
            }
            else
                PlayerPrefs.SetInt(FARM_TREE_KEY + i,0);
        }
    }
    void Start()
    {
       
    }
    private void OnEnable()
    {
        
        //  if(!GameManager.Instance.resetData)
        // {
            baseTransform = GameObject.FindGameObjectWithTag("Base").transform;
            workerCount = PlayerPrefs.GetInt("workerCount");
            for (int i = 0; i < workerCount; i++)
            {
                Instantiate(aiPrefab, spawnTransform.position, Quaternion.identity);
                // SetWorkerCount(workerCount +1);
                // workerText.text = workerCount.ToString() + "/" + max;
            }
            // SetWorkerCount(workerCount);
            for (int i = 0; i < farmTrees.Count; i++)
            {
                if(PlayerPrefs.GetInt(FARM_TREE_KEY+i) == 1)
                {
                    UnlockTree(i);
                }
                else
                    farmTrees[i].isUnLocked = false;
            }
        // }
        // else
        // {
        //     workerCount = 0;
            
        //     for (int i = 0; i < farmTrees.Count; i++)
        //     {
        //         PlayerPrefs.SetInt(FARM_TREE_KEY + i,0);
        //         farmTrees[i].isUnLocked = false;
        //     }
        // }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            fillAmountPlace.Trigger();
        }
    }
    // public void LoadData()
    // {
        
    //     for (int i = 0; i < farmTrees.Count; i++)
    //     {
    //         farmTrees[i].isUnLocked = data.farmTreeIsUnLocked[i];
    //         if (farmTrees[i].isUnLocked)
    //         {
    //             farmTrees[i].RestartAnim();
    //         }
    //     }
        
        
    // }
    // public void SaveData()
    // {
    //     data.farmTreeIsUnLocked.Clear();
    //     data.worketCount = workerCount;
        
    //     for (int i = 0; i < farmTrees.Count; i++)
    //     {
    //         data.farmTreeIsUnLocked.Add(farmTrees[i].isUnLocked);
    //     }
    // }
   
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

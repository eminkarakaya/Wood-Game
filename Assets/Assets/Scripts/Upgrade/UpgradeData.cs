using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum UpgradeType
{
    Move,AttackSpeed,BagCapacity
}
public class UpgradeData : MonoBehaviour 
{
    public bool ResetData;
    [SerializeField] private ParticleSystem particle;
    public UpgradeType upgradeType;
    [SerializeField] protected Data data;
    public Color disableColor,baseColor;
    public Cost cost;
    public Image upgradeIcon;
    public int level;
    public float upgrade;
    public TextMeshProUGUI levelText;
    public TextParse costText;
    private float costIncrementMultiplier = 1.30f;
    private float moveIncMultiplier = 1.1f, attackSpeedIncMultiplier = 1.1f, bagCapacityIncMultiplier = 1.3f;
    private void Awake() {
        
        

    }
    private float GetMultiplierForUpgradeType(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.Move:
                return moveIncMultiplier;
            case UpgradeType.AttackSpeed:
                return  attackSpeedIncMultiplier;
            case UpgradeType.BagCapacity:
                return bagCapacityIncMultiplier;
        }
        return 0;
    }
    private void OnDisable()
    {
        SaveData();

    }
    private void Start()
    {
        LoadData();
        baseColor = this.GetComponent<Image>().color;
        costText.AddEnoughDelegate(On);
        costText.AddNotEnoughDelegate(Under);
        float total = 100;
        for (int i = 0; i < level; i++)
        {
            total = total*costIncrementMultiplier;
        }
        cost.SetMoneyTotal((int)total);
        
        if(cost.GetMoney() == 0)
        {
            cost.SetMoneyTotal(100);
        }
    }
   
    public virtual void UpgradeBase()
    {
        
        switch (upgradeType)
        {
            case UpgradeType.Move:
                data.moveSpeed *= moveIncMultiplier;
                break;
            case UpgradeType.AttackSpeed:
                data.attackSpeed *= attackSpeedIncMultiplier;
                break;
            case UpgradeType.BagCapacity:
                data.bagCapacity = (data.bagCapacity * bagCapacityIncMultiplier);
                break;
        }
    }
    public void Upgrade()
    {
        if(GameManager.Instance.GetMoney() >= cost.GetMoney())
        {
            GameManager.Instance.SetMoney(-cost.GetMoney());
            SetCost();
            LevelRaise();
            UpgradeBase();
            particle.gameObject.transform.position = Movement.Instance.transform.position;
            particle.Play();
        }
    }
    
    private void LevelRaise()
    {
        level ++;
        levelText.text = "Level " + level.ToString();
        
    }
    public void SetCostText()
    {
        cost.SetMoneyText();
    }
    private void SetLevel(int value)
    {
        level = value;
        levelText.text = "Level " + level.ToString();
       
    }
    public void SetCost()
    {
        cost.SetMoney((int)(cost.GetMoney() * costIncrementMultiplier));
    }
    public void Under()
    {
        upgradeIcon.gameObject.SetActive(false);
        GetComponent<Image>().color = disableColor;
        // costText.enabled = false;
    }
    public void On()
    {
        upgradeIcon.gameObject.SetActive(true);
        // costText.enabled = true;
        GetComponent<Image>().color = baseColor;

    }

    public void LoadData()
    {
        if(ResetData)
        {
            Debug.Log("resetdata");
            level = 1;
            return;
        }
        switch (upgradeType)
        {
            case UpgradeType.Move:
                
                SetLevel(PlayerPrefs.GetInt("MoveLevel",level));
                break;
            case UpgradeType.AttackSpeed:
                SetLevel(PlayerPrefs.GetInt("AttackLevel",level));
                break;
            case UpgradeType.BagCapacity:
                SetLevel(PlayerPrefs.GetInt("BagLevel",level));
                break;
        }
    }

    public void SaveData()
    {
        switch (upgradeType)
        {
            case UpgradeType.Move:
                PlayerPrefs.SetInt("MoveLevel", level);
                break;
            case UpgradeType.AttackSpeed:
                PlayerPrefs.SetInt("AttackLevel", level);
                break;
            case UpgradeType.BagCapacity:
                PlayerPrefs.SetInt("BagLevel", level);
                break;
        }
    }
}

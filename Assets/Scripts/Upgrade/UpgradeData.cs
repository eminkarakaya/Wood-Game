using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum UpgradeType
{
    Move,AttackSpeed,BagCapacity
}
public class UpgradeData : MonoBehaviour , IDataPersistence
{
    public UpgradeType upgradeType;
    [SerializeField] protected Data data;
    public Color disableColor,baseColor;
    public Cost cost;
    public GameObject adObj;
    public Image upgradeIcon;
    public int level;
    public float upgrade;
    public TextMeshProUGUI levelText;
    public TextParse costText;
    private float costIncrementMultiplier = 1.30f;
    private float moveIncMultiplier = 1.1f, attackSpeedIncMultiplier = 1.1f, bagCapacityIncMultiplier = 1.1f;
    private void Start()
    {
        
        baseColor = this.GetComponent<Image>().color;
        costText.AddEnoughDelegate(On);
        costText.AddNotEnoughDelegate(Under);
        switch (upgradeType)
        {
            case UpgradeType.Move:
                cost.SetMoneyTotal((int)(level * moveIncMultiplier));
                break;
            case UpgradeType.AttackSpeed:
                cost.SetMoneyTotal((int)(level * attackSpeedIncMultiplier));
                break;
            case UpgradeType.BagCapacity:
                cost.SetMoneyTotal((int)(level * bagCapacityIncMultiplier));
                break;
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
                data.bagCapacity = (int)(data.bagCapacity * bagCapacityIncMultiplier);
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
        }
    }
    
    private void LevelRaise()
    {
        level ++;
        levelText.text = "Level " + level.ToString();
    }
    private void SetLevel(int value)
    {
        level = value;
        levelText.text = "Level " + level.ToString();
    }
    private void SetCost()
    {
        cost.SetMoney((int)(cost.GetMoney() * costIncrementMultiplier));
    }
    public void Under()
    {
        adObj.SetActive(true);
        upgradeIcon.gameObject.SetActive(false);
        GetComponent<Image>().color = disableColor;
        costText.enabled = false;
    }
    public void On()
    {
        adObj.SetActive(false);
        upgradeIcon.gameObject.SetActive(true);
        costText.enabled = true;
        GetComponent<Image>().color = baseColor;

    }

    public void LoadData(GameData data)
    {
        switch (upgradeType)
        {
            case UpgradeType.Move:
                SetLevel(data.moveLevel);
                break;
            case UpgradeType.AttackSpeed:
                SetLevel(data.attackLevel);
                break;
            case UpgradeType.BagCapacity:
                SetLevel(data.bagLevel);
                break;
        }
    }

    public void SaveData(GameData data)
    {
        switch (upgradeType)
        {
            case UpgradeType.Move:
                data.moveLevel = level;
                break;
            case UpgradeType.AttackSpeed:
                data.attackLevel = level;
                break;
            case UpgradeType.BagCapacity:
                data.bagLevel = level;
                break;
        }
    }
}

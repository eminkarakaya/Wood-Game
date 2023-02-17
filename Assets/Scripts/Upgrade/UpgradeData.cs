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
    [SerializeField] private ParticleSystem particle;
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
    private void OnEnable()
    {
        LoadData();
    }
    private void OnDisable()
    {
        SaveData();
    }
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
            particle.gameObject.transform.position = Movement.Instance.transform.position;
            particle.Play();
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

    public void LoadData()
    {
        // if(!GameManager.Instance.resetData)
        // {
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
        // }
        // else
        // {
        //     switch (upgradeType)
        //     {
        //         case UpgradeType.Move:
                    
        //             level = 0;
        //             break;
        //         case UpgradeType.AttackSpeed:
        //             level = 0;
        //             break;
        //         case UpgradeType.BagCapacity:
        //             level = 0;
        //             break;
        //     }

        // }
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

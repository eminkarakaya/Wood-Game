using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class GameManager : Singleton<GameManager> , IDataPersistence
{
    public Transform baseTransform;
    public GameObject goldPrefab;
    [SerializeField] private int _money;
    TextParse[] textParses;
    [SerializeField] private TextMeshProUGUI _moneyText,_woodText;
    public int GetMoney()
    {
        return _money;
    }
    
    public void SetMoney(int value)
    {
        _money += value;
        _moneyText.text = CaclText(_money);
        textParses = FindObjectsOfType<TextParse>();
        for (int i = 0; i < textParses.Length; i++)
        {
            textParses[i].Check(textParses[i].GetComponent<Cost>().GetMoney());
        }
    }


    public static string CaclText(float value)
    {
        if (value == 0)
        {
            return "0";
        }
        if (value < 1000)
        {
            return String.Format("{0:0.0}", value);
        }
        else if (value >= 1000 && value < 1000000)
        {
            return String.Format("{0:0.0}", value / 1000) + "k";
        }
        else if (value >= 1000000 && value < 1000000000)
        {
            return String.Format("{0:0.0}", value / 1000000) + "m";
        }
        else if (value >= 1000000000 && value < 1000000000000)
        {
            return String.Format("{0:0.0}", value / 1000000000) + "b";
        }
        else if (value >= 1000000000000 && value < 1000000000000000)
        {
            return String.Format("{0:0.0}", value / 1000000000000) + "t";
        }
        else if (value >= 1000000000000000 && value < 1000000000000000000)
        {
            return String.Format("{0:0.0}", value / 1000000000000000) + "aa";
        }
        else if (value >= 1000000000000000000)
        {
            return String.Format("{0:0.0}", value / 1000000000000000) + "ab";
        }
        return value.ToString();
    }

    public void LoadData(GameData data)
    {
        SetMoney(data.gold);
    }

    public void SaveData(GameData data)
    {
        data.gold = GetMoney();
    }
}

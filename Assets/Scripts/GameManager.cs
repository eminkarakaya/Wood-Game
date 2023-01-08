using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class GameManager : Singleton<GameManager> , IDataPersistence
{
    [SerializeField] private int _money, _wood;
    TextParse[] textParses;
    [SerializeField] private TextMeshProUGUI _moneyText,_woodText;
    private void Awake()
    {
        SetMoney(0);
    }
    public void SetWood(int value)
    {
        _wood += value;
        _woodText.text = CaclText(_wood);
    }
    public int GetWood()
    {
        return _wood;
    }
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

    public void LoadData(GameData data)
    {
        //_money = data.money;
    }

    public void SaveData(GameData data)
    {
        //data.money = _money;
    }

    public void SaveData(ref GameData data)
    {
        throw new NotImplementedException();
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
}

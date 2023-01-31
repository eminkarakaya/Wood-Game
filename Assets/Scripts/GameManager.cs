using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;
    public Transform baseTransform;
    public GameObject goldPrefab;
    [SerializeField] private int _money;
    TextParse[] textParses;
    [SerializeField] private TextMeshProUGUI _moneyText,_woodText;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Found more than one game manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        SetMoney(0);
    }
    private void OnEnable()
    {
        _money = PlayerPrefs.GetInt("Gold");
        _moneyText.text = CaclText(_money);

    }
    private void OnDisable()
    {
        Debug.Log("save gold");
        PlayerPrefs.SetInt("Gold", GetMoney());
        
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

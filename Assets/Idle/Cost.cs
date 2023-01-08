using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    [SerializeField] private int _currentGold;
    public int _gold;
    public TextParse textParse;
    void Start()
    {
        
        textParse = GetComponent<TextParse>();
        SetMoney(0);
    }
    public void SetMoney(int value)
    {
        _currentGold += value;
        textParse.Check(_currentGold);
        textParse.text = GameManager.CaclText(_currentGold);
    }
    public void SetMoneyTotal(int value)
    {
        _currentGold = value;
        textParse.Check(_currentGold);
        textParse.text = GameManager.CaclText(_currentGold);
    }
    public int GetMoney()
    {
        return _currentGold;
    }
}

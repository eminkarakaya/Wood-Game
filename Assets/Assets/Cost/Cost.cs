using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    [SerializeField] private int _currentGold;
    public int maxGold;
    public TextParse textParse;
    void Awake()
    {
           
        textParse = GetComponent<TextParse>();

    }
    private void Start()
    {
        MoneyRaise(0);
        
    }
    public void MoneyRaise(int value)
    {
        _currentGold += value;
        textParse.Check(_currentGold);
        textParse.text = GameManager.CaclText(_currentGold);
    }
    public void SetMoneyText()
    {
        textParse.Check(_currentGold);
        textParse.text = GameManager.CaclText(_currentGold);
    }
    public void SetMoney(int value)
    {
        // Debug.Log(value);
        _currentGold = value;
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

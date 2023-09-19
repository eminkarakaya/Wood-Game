using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextParse : TextMeshProUGUI
{
    public delegate void OnEnoughMoney();
    private OnEnoughMoney onEnoughMoney;
    public delegate void OnNotEnoughMoney();
    private OnNotEnoughMoney onNotEnoughMoney;
    Color _color = new Color(49, 207, 26, 255);
    public override Color color { get => base.color; set => base.color = value; }
    protected override void OnEnable()
    {
        base.OnEnable();
        onEnoughMoney += EnoughMoney;
        onNotEnoughMoney += NotEnoughMoney;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        onEnoughMoney -= EnoughMoney;
        onNotEnoughMoney -= NotEnoughMoney;
    }
    public void Check(float value)
    {
        if (GameManager.Instance.GetMoney() < value)
        {
            onNotEnoughMoney?.Invoke();

        }
        else
        {
            onEnoughMoney?.Invoke();

        }
    }
    public void EnoughMoney()
    {
        color = _color;
    }
    public void NotEnoughMoney()
    {
        
        color = Color.red;
    }
    public void AddEnoughDelegate(OnEnoughMoney funcs)
    {
        onEnoughMoney += funcs;
    }
    public void AddNotEnoughDelegate(OnNotEnoughMoney funcs)
    {
        onNotEnoughMoney += funcs;
    }
}
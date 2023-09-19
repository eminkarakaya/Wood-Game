using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health : MonoBehaviour
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private float _hp, _maxHp;

    public float Hp
    {
        get { return _hp; }
        set 
        {
            _hp = value;
            if(_hpSlider != null)
            {
                _hpSlider.value = _hp;
            }
            if(_hpText != null)
            {
                _hpText.text = _hp.ToString();
            }
        }
    }
    private void Start()
    {
        if(_hpSlider!=null)
        {
            _hpSlider.maxValue = _maxHp;
        }
        if (_hpText != null)
        {
            _hpText.text = _hp.ToString();
        }
        Hp = _maxHp;
    }
    void Death()
    {
        Debug.Log("Death");
    }

}

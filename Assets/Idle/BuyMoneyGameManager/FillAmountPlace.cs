
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillAmountPlace : MonoBehaviour
{
    public delegate void OnFill();
    public OnFill onFill;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private GameObject aiPrefab;
    public Image fillImage;
    public Cost money;
    private float _width, _height;
    public float time = 10;
    public float remainingTime;
    private void Start()
    {
        remainingTime = 0;
        money = GetComponentInChildren<Cost>();
        _width = this.GetComponent<RectTransform>().rect.width;
        _height = this.GetComponent<RectTransform>().rect.height;
        GetComponent<BoxCollider>().size = new Vector3(_width,_height,5);
    }
    public void Trigger()
    {
        onFill?.Invoke();
        Instantiate(aiPrefab, spawnTransform.position, Quaternion.identity);
    }
    public void ResetImage()
    {
        money.SetMoneyTotal(money.maxGold);
        remainingTime = 0;
        fillImage.fillAmount = 0;
    }
}

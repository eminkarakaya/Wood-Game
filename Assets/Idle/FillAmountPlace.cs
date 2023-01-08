
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FillAmountPlace : MonoBehaviour
{
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        StartCoroutine(asd(money.GetMoney(), 0));
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
            
    //        StopAllCoroutines();
            
    //    }
    //}
    
    //IEnumerator asd(float current,float target)
    //{
    //    var passed = remainingTime;
    //    var initPos = current;
    //    while(passed < time)
    //    {
    //        passed += Time.deltaTime;
    //        remainingTime += Time.deltaTime;
    //        var normalized = passed / time;
    //        fillImage.fillAmount += Time.deltaTime / time;
    //        var _money = Mathf.Lerp(initPos, target, normalized);
    //        var _oldMoney = money.GetMoney();
    //        money.SetMoneyTotal((int) _money);
    //        GameManager.instance.SetMoney(_oldMoney - money.GetMoney());
    //        yield return null;
    //    }
    //    // dolunca olcaklar

    //}
}

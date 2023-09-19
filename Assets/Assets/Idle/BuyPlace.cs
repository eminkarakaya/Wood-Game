using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPlace : MonoBehaviour
{
    FillPlace fill;
    Collect collect;
    IEnumerator Fill()
    {

        while(true)
        {
            if(fill.current == fill.max)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(fill.timeOffset);
                
            }
        }

        //var passed = fill.remainingTime;
        //var initPos = current;
        //while (passed < fill.time)
        //{
        //    passed += Time.deltaTime;
        //    fill.remainingTime += Time.deltaTime;
        //    var normalized = passed / fill.time;
        //    fill.fillImage.fillAmount += Time.deltaTime / fill.time;
        //    var _money = Mathf.Lerp(initPos, target, normalized);
        //    var _oldMoney = fill.money.GetMoney();
        //    fill.money.SetMoneyTotal((int)_money);
        //    GameManager.instance.SetMoney(fill.money.GetMoney() - _oldMoney);
        //    yield return null;
        //}
        // dolunca olcaklar

    }
    private void Drop()
    {
        fill.SetCurrent();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FillImage")
        {
            collect = other.GetComponent<Collect>();
            fill = other.GetComponent<FillPlace>();
            StartCoroutine(Fill());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FillImage")
        {
            StopAllCoroutines();
        }
    }
}

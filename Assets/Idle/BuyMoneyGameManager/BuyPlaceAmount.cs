using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlaceAmount : MonoBehaviour
{
    FillAmountPlace fill;
    IEnumerator Fill(float current, float target)
    {
        var passed = fill.remainingTime;
        var initPos = current;
        while (passed < fill.time)
        {
            passed += Time.deltaTime;
            fill.remainingTime += Time.deltaTime;
            var normalized = passed / fill.time;
            fill.fillImage.fillAmount += Time.deltaTime / fill.time;
            var _money = Mathf.Lerp(initPos, target, normalized);
            var _oldMoney = fill.money.GetMoney();
            fill.money.SetMoneyTotal((int)_money);
            GameManager.Instance.SetMoney( fill.money.GetMoney()-_oldMoney);
            if(_money == target)
            {
                fill.Trigger();
                fill.ResetImage();

            }
            yield return null;
        }
        // dolunca olcaklar

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FillImage")
        {
            fill = other.GetComponent<FillAmountPlace>();
            StartCoroutine(Fill(fill.money.GetMoney(), 0));
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private int count;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            GameManager.Instance.SetMoney(count);
            GoldAnim.instance.EarnGoldAnim2(count, other.transform);
            Destroy(this.gameObject);
        }
    }

}

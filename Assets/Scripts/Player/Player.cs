using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Gold")
        {
            int count = other.GetComponent<Gold>().count;
            GameManager.Instance.SetMoney(count);
            GoldAnim.instance.EarnGoldAnim2(count, this.transform);
            Destroy(other.gameObject);
            if(!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}

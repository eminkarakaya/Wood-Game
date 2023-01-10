using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
public class Tree : MonoBehaviour
{
    [SerializeField] Vector3 minRange,maxRange;
    [SerializeField] private Transform[] childs;
    int index;
    public bool isDeath;
    private void Start()
    {
        childs = GetComponentsInChildren<Transform>();
        index = 1;
    }
    public void AIHit()
    {
        childs[index].gameObject.SetActive(false);
        index++;

        if (index == childs.Length)
        {
            Collider[] colliders = GetComponents<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
            tag = "Untagged";
            isDeath = true;
            return;
        }
        else isDeath = false;
    }
    public void Hit()
    {
        childs[index].gameObject.SetActive(false);
        index++;
        Vector3 random = new Vector3(transform.position.x,0,transform.position.z) + new Vector3(Random.Range(minRange.x, maxRange.x), 0, Random.Range(minRange.z, maxRange.z));
        var obj = CollectManager.Instance.SpawnObject(transform.position, 1);
        obj.transform.DOJump(random, 1, 1, .4f);
        if (index == childs.Length)
        {
            Collider[] colliders = GetComponents<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
            tag = "Untagged";
            isDeath = true;
            return;
        }
        else isDeath = false;
        
    }
}

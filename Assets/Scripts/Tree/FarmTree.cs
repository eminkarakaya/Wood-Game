using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FarmTree : TreeBase
{
    public int farmIndex;
    public bool isUnLocked;
    [SerializeField] private float time;
    protected override IEnumerator RestartCouroutine()
    {
        yield return new WaitForSeconds(time);
        Restart();
    }
    IEnumerator NextFrame(Collider collider)
    {
        yield return 0;
        collider.isTrigger = true;
    }
    public void Restart()
    {
        index = 1;
        Collider[] colliders = GetComponents<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].isTrigger = false;
            colliders[i].enabled = true;
            StartCoroutine(NextFrame(colliders[i]));
        }
        foreach (var item in childs)
        {
            item.gameObject.SetActive(true);
        }
        tag = "Tree";
        isDeath = false;
    }
    public void RestartAnim()
    {
        this.gameObject.SetActive(true);
    }
    
}
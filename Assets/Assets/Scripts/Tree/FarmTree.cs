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
            item.GetComponent<TreeHp>().hp = data.hp;
            item.gameObject.SetActive(true);
        }
        ReviveAnim();
        tag = "Tree";
        isDeath = false;
    }
    public void ReviveAnim(System.Action onComplate)
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one * 1.3f, .3f).OnComplete(()=> transform.DOScale(Vector3.one, .1f)).SetDelay(.5f).OnComplete(()=>onComplate?.Invoke());
    }
    public void ReviveAnim()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one * 1.3f, .3f).OnComplete(() => transform.DOScale(Vector3.one, .1f));
    }
    public void RestartAnim()
    {
        this.gameObject.SetActive(true);
    }
    
}
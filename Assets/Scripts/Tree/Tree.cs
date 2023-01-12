using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
public class Tree : MonoBehaviour
{
    [SerializeField] private TreeData data;
    [SerializeField] public Vector3 minRange,maxRange;
    [SerializeField] private Transform[] childs;
    [SerializeField] int index;
    public bool isDeath;
    private void Start()
    {
        childs = GetComponentsInChildren<Transform>();
        index = 1;
        AddTreeData();
    }
    private void AddTreeData()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            TreeHp hp = childs[i].gameObject.AddComponent(typeof(TreeHp)) as TreeHp;
            hp.hp = data.hp;
            hp.tree = this;
        }
    }
    public void TreeAnimation()
    {
        transform.DOScale(Vector3.one * 1.1f, .2f).OnComplete(() => transform.DOScale(Vector3.one, .2f));
        transform.DOShakeRotation(.2f, 10, 5, 20);
    }
    public void AIHit(float damage,System.Action action)
    {
        if (childs.Length == index)
            return;
        TreeAnimation();
        TreeHp hp = childs[index].GetComponent<TreeHp>();
        hp.AIHit(damage,action);
    }
    public void Hit(float damage)
    {
        if (childs.Length == index)
            return;
        TreeHp hp = childs[index].GetComponent<TreeHp>();
        hp.Hit(damage);
        TreeAnimation();
    }
    public void CheckHp()
    {
        
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
    public void HpDeath()
    {
        Vector3 random = new Vector3(transform.position.x, 0, transform.position.z) + new Vector3(Random.Range(minRange.x, maxRange.x), 0, Random.Range(minRange.z, maxRange.z));
        var obj = CollectManager.Instance.SpawnObject(transform.position, 1);
        obj.GetComponent<Collider>().enabled = true;
        obj.transform.DOJump(random, 1, 1, .4f);
        childs[index].gameObject.SetActive(false);
        index++;
        CheckHp();
    }
    public void AIHpDeath(System.Action action)
    {
        childs[index].gameObject.SetActive(false);
        index++;
        action?.Invoke();
        CheckHp();
    }
}

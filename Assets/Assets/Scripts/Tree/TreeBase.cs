using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBase : MonoBehaviour
{
    [SerializeField] public GameObject wood;
    public delegate void OnDestroyTree();
    public delegate void OnHpDeathTree();
    public OnDestroyTree onDestroyTree;
    public OnHpDeathTree onHpDeathTree;
    [SerializeField] protected TreeData data;
    [SerializeField] public Vector3 minRange, maxRange;
    [SerializeField] protected Transform[] childs;
    [SerializeField] protected Transform parent;
    [SerializeField] protected int index;
    public bool isDeath;
    private void Start()
    {
        parent = transform.GetChild(0);
        childs = parent.GetComponentsInChildren<Transform>();
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
    public void AIHit(float damage, System.Action action)
    {
        if (childs.Length == index)
            return;
        TreeAnimation();
        TreeHp hp = childs[index].GetComponent<TreeHp>();
        hp.AIHit(damage, action);
    }
    protected virtual IEnumerator RestartCouroutine()
    {
        yield return null;
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
            //death
            Collider[] colliders = GetComponents<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
            tag = "Untagged";
            StartCoroutine(RestartCouroutine());
            isDeath = true;
            onDestroyTree?.Invoke();
            return;
        }
        else isDeath = false;
    }
    public void HpDeath()
    {
        Vector3 random = new Vector3(transform.position.x, 0, transform.position.z) + new Vector3(Random.Range(minRange.x, maxRange.x), 0, Random.Range(minRange.z, maxRange.z));
        var obj = Instantiate(wood, transform.position, Quaternion.identity);
        obj.GetComponent<Collider>().enabled = true;
        MeshRenderer meshRenderer = obj.GetComponentInChildren<MeshRenderer>();
        QuickOutline outline = meshRenderer.gameObject.AddComponent(typeof(QuickOutline)) as QuickOutline;
        outline.OutlineColor = meshRenderer.materials[0].color;
        obj.transform.DOJump(random, 1, 1, .4f);
        RotateAnimation rt = obj.AddComponent(typeof(RotateAnimation)) as RotateAnimation;
        childs[index].gameObject.SetActive(false);
        index++;
        onHpDeathTree?.Invoke();
        CheckHp();
    }
    public void AIHpDeath(System.Action action)
    {
        childs[index].gameObject.SetActive(false);
        index++;
        action?.Invoke();
        CheckHp();
        onHpDeathTree?.Invoke();
    }
    public int GetCurrentIndex()
    {
        return index;
    }
    public TreeHp GetTreeHp()
    {
        if(index >= childs.Length)
        {
            return null;
        }
        return childs[index].GetComponent<TreeHp>();
    }

}

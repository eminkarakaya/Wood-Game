using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OnTheTree : MonoBehaviour
{
    [SerializeField] private TreeBase treeBase;
    [SerializeField] private float offset;
    public delegate void OnGround();
    public OnGround onGround;
    private void Start()
    {
        treeBase.onHpDeathTree += Fall;
    }
    private void OnDisable()
    {
        treeBase.onHpDeathTree -= Fall;
    }
    public void Fall()
    {
        TreeHp treehp = treeBase.GetTreeHp();
        if(treehp == null)
        {
            onGround?.Invoke();
            transform.DOMoveY(0 + offset, 1f);
        }
        else
            transform.DOMoveY(treehp.transform.position.y + offset/5, .2f);
    }
}

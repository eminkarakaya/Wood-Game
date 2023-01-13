using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OnTheTree : MonoBehaviour
{
    [SerializeField] private TreeBase treeBase;
    [SerializeField] private float offset;
    private void Start()
    {
        treeBase.onHpDeathTree += Fall;
    }
    public void Fall()
    {
        TreeHp treehp = treeBase.GetTreeHp();
        if(treehp == null)
        {
            transform.DOMoveY(0 + offset, .2f);
        }
        else
            transform.DOMoveY(treehp.transform.position.y + offset/2, .2f);
    }
}

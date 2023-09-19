using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
public class Tree : TreeBase
{
    private void OnEnable()
    {
        onDestroyTree += RemoveTree;
    }
    private void OnDisable()
    {
        onDestroyTree -= RemoveTree;
    }
    public void RemoveTree()
    {
        if(TreeManager.Instance.allTrees.Contains(this))
            TreeManager.Instance.allTrees.Remove(this);
        TreeManager.Instance.CheckFinish();
    }
}
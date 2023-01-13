using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerMove : MoveState
{
    protected override TreeBase FindTree()
    {
        FarmTree[] trees = FindObjectsOfType<FarmTree>();
        List<FarmTree> treeList = new List<FarmTree>();
        foreach (var item in trees)
        {
            if (item.isDeath)
                continue;
            treeList.Add(item);
        }
        if (treeList.Count == 0)
            return null;

        FarmTree nearest = treeList[0];
        float nearDistance = Vector3.Distance(transform.position, nearest.transform.position);
        foreach (var item in treeList)
        {
            float distnce = Vector3.Distance(transform.position, item.transform.position);
            if (nearDistance > distnce)
            {
                nearDistance = distnce;
                nearest = item;
            }
        }
        targetTree = nearest;
        target = targetTree.transform.position;
        return nearest;
    }
}

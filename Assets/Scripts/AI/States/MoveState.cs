using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class MoveState : StateBase
{
    public Vector3 target;
    public TreeBase targetTree;
    public Transform baseTransform;
    public override void StartState(AIAnimation aIAnimation)
    {

        aIAnimation.Move();
        ai.StartMove();        
        if(ai.GetComponent<Collect>().IsBagFull())
        {
            ai.CurrentState = ai.backBaseState;
            return;
        }

        if(FindTree()== null)
        {
            ai.CurrentState = ai.IdleState;
            return;
        }
        target = FindTree().transform.position;
        ai.SetDestination(target);
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {
        if(targetTree.isDeath)
        {
            targetTree = FindTree();
            if (targetTree == null)
            {
                targetTree = FindTree();
                if (targetTree == null)
                {
                    ai.CurrentState = ai.IdleState;
                    return;
                }
            }
            else
                ai.SetDestination(target);

        }
    }
    public override void ExitState(AIAnimation aIAnimation)
    {
        
    }
    

    public override void TriggerEnterState(AIAnimation aIAnimation, Collider other)
    {
        if (other.gameObject == targetTree.gameObject && ai.CurrentState != ai.backBaseState)
        {
            ai.treeState.targetTree = targetTree;
            ai.CurrentState = ai.treeState;
        }
    }
    protected virtual TreeBase FindTree()
    {
        Tree[] trees = FindObjectsOfType<Tree>();
        List<Tree> treeList = new List<Tree>();
        foreach (var item in trees)
        {
            if (item.isDeath)
                continue;
            treeList.Add(item);
        }
        if (treeList.Count == 0)
            return null;

        Tree nearest = treeList[0];
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

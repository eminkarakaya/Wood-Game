using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBaseState : StateBase
{
    Collect collect;
    public override void StartState(AIAnimation aIAnimation)
    {
        collect = ai.GetComponent<Collect>();
        aIAnimation.Move();
        ai.SetDestination(CollectManager.Instance.baseTransform);
        ai.StartMove();
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {
        if(Vector3.Distance(transform.position,CollectManager.Instance.baseTransform.position)<.4f)
        {
            ai.CurrentState = ai.waitBagState;
        }
        if(collect.GetCollectableObjects().Count == 0)
        {
            ai.CurrentState = ai.moveState;
        }
    }
    public override void TriggerEnterState(AIAnimation aIAnimation, Collider other)
    {
        
    }

    public override void ExitState(AIAnimation aIAnimation)
    {

    }
}

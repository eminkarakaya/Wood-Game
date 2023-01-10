using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBaseState : StateBase
{

    public override void StartState(AIAnimation aIAnimation)
    {
        aIAnimation.Move();
        Debug.Log("Backstate");
        ai.SetDestination(CollectManager.Instance.baseTransform);
        ai.StartMove();
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {

    }
    public override void TriggerEnterState(AIAnimation aIAnimation, Collider other)
    {
        
    }

    public override void ExitState(AIAnimation aIAnimation)
    {

    }
}

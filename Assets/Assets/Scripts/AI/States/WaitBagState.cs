using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBagState : StateBase
{

    Collect collect;
    public override void StartState(AIAnimation aIAnimation)
    {
        collect = ai.GetComponent<Collect>();
        aIAnimation.Idle();
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {
        if (collect.GetCollectableObjects().Count == 0)
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

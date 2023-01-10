using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBagState : StateBase
{
    

    public override void StartState(AIAnimation aIAnimation)
    {
        aIAnimation.Idle();
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

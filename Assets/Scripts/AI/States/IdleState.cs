using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    
    public override void StartState(AIAnimation aIAnimation)
    {
        ai.Stop();
        aIAnimation.Idle();
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {
        if(IsEmptyTreeList())
        {
            ai.CurrentState = ai.moveState;
        }
    }
    public override void ExitState(AIAnimation aIAnimation)
    {
        
    }

    public override void TriggerEnterState(AIAnimation aIAnimation, Collider other)
    {
        
    }
    private bool IsEmptyTreeList()
    {
        return TreeManager.Instance.allTrees.Count == 0;
    }
}

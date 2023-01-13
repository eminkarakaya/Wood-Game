using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState : StateBase
{
    public TreeBase targetTree;
    [SerializeField] HitAI hit;

    public override void StartState(AIAnimation aIAnimation)
    {
        aIAnimation.Hit();
        ai.Stop();
        hit = GetComponentInParent<HitAI>();
        hit.enabled = true;
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {
        
    }
    public override void ExitState(AIAnimation aIAnimation)
    {

    }

    public override void TriggerEnterState(AIAnimation aIAnimation, Collider other)
    {
        
    }
}

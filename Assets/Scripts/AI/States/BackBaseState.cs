using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBaseState : StateBase
{
    Collect collect;
    [SerializeField] Transform baseTransform;
    
    public override void StartState(AIAnimation aIAnimation)
    {
        FarmerMove farmerMove = transform.parent.GetComponentInChildren<FarmerMove>();
        if(farmerMove != null)
            baseTransform = FarmManager.Instance.drop.transform;
        else
            baseTransform = FarmManager.Instance.baseTransform;
        collect = ai.GetComponent<Collect>();
        aIAnimation.Move();
        ai.SetDestination(baseTransform);
        ai.StartMove();
    }

    public override void UpdateState(AIAnimation aIAnimation)
    {
        if(Vector3.Distance(transform.position,baseTransform.position)<.4f)
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

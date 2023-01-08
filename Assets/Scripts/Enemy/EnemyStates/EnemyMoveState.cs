using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    
    public override void OnTriggerEnterState(EnemyAnimations customerAnimations, Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            enemy.enemyAttackState.healt = other.GetComponent<Health>();
            enemy.CurrentState = enemy.enemyAttackState;
        }
    }

    public override void StartState(EnemyAnimations customerAnimations)
    {
        customerAnimations.WalkAnim();
    }

    public override void UpdateState(EnemyAnimations customerAnimations)
    {
        Debug.Log(rb);
        rb.velocity = - Vector3.forward * enemy.enemyData.moveSpeed;
    }

}

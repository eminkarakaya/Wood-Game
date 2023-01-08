using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    public Health healt;
    public override void StartState(EnemyAnimations customerAnimations)
    {
        
        customerAnimations.Attack();
    }

    public override void UpdateState(EnemyAnimations customerAnimations)
    {

    }
    public override void OnTriggerEnterState(EnemyAnimations customerAnimations, Collider other)
    {

    }
    public void Attack()
    {
        healt.Hp -= enemy.enemyData.damage;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanAnimationEvent : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void Attack()
    {
        enemy.enemyAttackState.Attack();
    }
}

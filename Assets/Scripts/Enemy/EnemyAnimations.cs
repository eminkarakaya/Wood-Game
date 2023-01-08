using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    const string WALK = "Walk";
    const string ATTACK = "Attack";
    Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void WalkAnim()
    {
        animator.SetBool(WALK, true);
        animator.SetBool(ATTACK, false);
    }
    public void Attack()
    {
        animator.SetBool(ATTACK, true);
        animator.SetBool(WALK, false);

    }
}

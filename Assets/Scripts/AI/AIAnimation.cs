using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    Animator anim;
    const string MOVE = "Move";
    const string ATTACK = "Hit";
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Hit()
    {
        anim.SetBool("Hit", true);
        anim.SetBool("Move", false);
    }
    public void Move()
    {
        anim.SetBool("Move", true);
        anim.SetBool("Hit", false);
    }
    public void Idle()
    {
        anim.SetBool("Hit", false);
        anim.SetBool("Move", false);
    }
}

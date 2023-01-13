using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TreeHp : MonoBehaviour
{
    public TreeBase tree;
    public float hp;
    public TreeHp(float hp)
    {
        this.hp = hp;
    }
    public void Death()
    {
        tree.HpDeath();
        enabled = false;
    }
    public void AIDeath(System.Action action)
    {
        enabled = false;
        tree.AIHpDeath(action);
    }
    public void Hit(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Death();
        }
    }
    public void AIHit(float damage,System.Action action)
    {
        hp -= damage;
        if (hp <= 0)
        {
            AIDeath(action);
        }
    }
}

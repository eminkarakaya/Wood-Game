using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : ScriptableObject
{
    [SerializeField] protected float defaultMove,defaultAttack;
    [SerializeField] protected int defaultBag;
    public float moveSpeed, attackSpeed;
    public int bagCapacity;
    public Data()
    {
        moveSpeed = 2f;
        attackSpeed = 1f;
        bagCapacity = 10;
    }
}

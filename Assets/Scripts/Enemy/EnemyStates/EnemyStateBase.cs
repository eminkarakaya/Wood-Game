using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStateBase : MonoBehaviour
{
    [SerializeField] protected Enemy enemy;
    protected Rigidbody rb;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        rb = enemy.GetComponent<Rigidbody>();
    }
    public abstract void StartState(EnemyAnimations customerAnimations);
    public abstract void UpdateState(EnemyAnimations customerAnimations);
    public abstract void OnTriggerEnterState(EnemyAnimations customerAnimations,Collider other);

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    private EnemyAnimations enemyAnimations;
    [Header("States")]
    [Space(10)]
    [SerializeField] public EnemyIdleState enemyIdleState;
    [SerializeField] public EnemyMoveState enemyMoveState;
    [SerializeField] public EnemyAttackState enemyAttackState;
    [SerializeField] public EnemyDeathState enemyDeathState;

    [Space(10)]
    [SerializeField] private EnemyStateBase _currentState;
    public EnemyStateBase CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            _currentState.StartState(enemyAnimations);
        }
    }

    private void Start()
    {
        enemyAnimations = GetComponent<EnemyAnimations>();
        CurrentState.StartState(enemyAnimations);
    }
    private void Update()
    {
        CurrentState.UpdateState(enemyAnimations);
    }
    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnterState(enemyAnimations,other);
    }

    public void ChangeCurrentState(EnemyStateBase state)
    {
        CurrentState = state;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private AIData aiData;
    private AIAnimation aiAnimations;
    [Header("States")]
    [Space(10)]
    [SerializeField] public BackBaseState backBaseState;
    [SerializeField] public MoveState moveState;
    [SerializeField] public TreeState treeState;
    [SerializeField] public WaitBagState waitBagState;
    [SerializeField] public IdleState IdleState;
    [Space(10)]
    [SerializeField] private StateBase _currentState;
    private NavMeshAgent agent;
    public StateBase CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            _currentState.StartState(aiAnimations);
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = aiData.moveSpeed;
        aiAnimations = GetComponent<AIAnimation>();
        CurrentState.StartState(aiAnimations);
    }
    private void Update()
    {
        _currentState.UpdateState(aiAnimations);
    }
    private void OnTriggerEnter(Collider other)
    {
        CurrentState.TriggerEnterState(aiAnimations, other);
    }
    public void SetDestination(Transform destination)
    {
        agent.SetDestination(destination.position);
    }
    public void ChangeCurrentState(StateBase state)
    {
        CurrentState = state;
    }
    public void SetDestination(Vector3 target)
    {
        agent.SetDestination(target);
    }
    
    public void Stop()
    {
        agent.speed = 0;
    }
    public void StartMove()
    {
        agent.speed = aiData.moveSpeed;
    }
}

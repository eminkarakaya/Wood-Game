using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    [SerializeField] protected AI ai;
    private void Awake()
    {
        ai = GetComponentInParent<AI>();   
    }
    public abstract void StartState(AIAnimation aIAnimation);
    public abstract void UpdateState(AIAnimation aIAnimation);
    public abstract void ExitState(AIAnimation aIAnimation);
    public abstract void TriggerEnterState(AIAnimation aIAnimation, Collider other);


}

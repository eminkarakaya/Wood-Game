using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollToggle : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider mainCollider;
    [SerializeField] private Rigidbody mainRb;
    [SerializeField] private GameObject rigObj;
    [SerializeField] Collider[] colliders;
    [SerializeField] Rigidbody[] rigidbodies;
    private void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            RagdollModeOn();
        }
    }
    void GetRagdollBits()
    {
        colliders = rigObj.GetComponentsInChildren<Collider>();
        rigidbodies = rigObj.GetComponentsInChildren<Rigidbody>();
    }
    void RagdollModeOff()
    {
        foreach (var item in colliders)
        {
            item.enabled = false;
        }
        foreach (var item in rigidbodies)
        {
            item.isKinematic = true;
        }
        if(mainCollider != null)
            mainCollider.enabled = true;
        if(mainRb != null)
            mainRb.isKinematic = false;
        animator.enabled = true;
    }

    void RagdollModeOn()
    {
        foreach (var item in colliders)
        {
            item.enabled = true;
        }
        foreach (var item in rigidbodies)
        {
            item.isKinematic = false;
        }
        if(mainCollider != null)
            mainCollider.enabled = false;
        if(mainRb != null)
            mainRb.isKinematic = true;
        animator.enabled = false;
    }
}

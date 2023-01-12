using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAI : MonoBehaviour
{
    [SerializeField] private Data data;
    public List<Tree> trees;
    Animator animator;
    public Ax ax;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", data.attackSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Enter(other.GetComponent<Tree>());
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Exit(other.GetComponent<Tree>());

        }
    }
    public void Enter(Tree tree)
    {
        trees.Add(tree);
        if (trees.Count > 0)
        {
            animator.SetBool("Hit", true);
        }
        
    }
    public void Exit(Tree tree)
    {
        if (trees.Contains(tree))
        {
            trees.Remove(tree);
        }
        if (trees.Count == 0)
        {
            animator.SetBool("Hit", false);
            if (TryGetComponent(out AI ai))
            {
                ai.CurrentState = ai.moveState;
            }
        }
    }
    public void Attack()
    {
        animator.SetFloat("Speed", data.attackSpeed);
        Collect collect = GetComponent<Collect>();
        for (int i = 0; i < trees.Count; i++)
        {
            trees[i].AIHit(ax.damage,()=>
            {
                var obj = CollectManager.Instance.SpawnObject(transform.position, 1);
                collect.CollectItem(obj.GetComponent<Collectable>());
            });
            if (trees[i].isDeath)
            {
                Exit(trees[i]);
                i--;
            }

        }
        if (GetComponent<Collect>().IsBagFull())
        {
            GetComponent<AI>().CurrentState = GetComponent<AI>().backBaseState;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAI : MonoBehaviour
{
    public List<Tree> trees;
    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Enter(other.GetComponent<Tree>());
            //if (!trees.Contains(other.GetComponent<Tree>()))
            //{
            //    trees.Add(other.GetComponent<Tree>());
            //}
            //if (trees.Count > 0)
            //{
            //    animator.SetBool("Hit", true);
            //}
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Exit(other.GetComponent<Tree>());
            //if (trees.Contains(other.GetComponent<Tree>()))
            //{
            //    trees.Remove(other.GetComponent<Tree>());
            //}
            //if(trees.Count == 0)
            //{
            //    animator.SetBool("Hit", false);
            //}
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
        Collect collect = GetComponent<Collect>();
        for (int i = 0; i < trees.Count; i++)
        {
            var obj = CollectManager.Instance.SpawnObject(transform.position, 1);
            collect.CollectItem(obj.GetComponent<Collectable>());
            trees[i].AIHit();
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

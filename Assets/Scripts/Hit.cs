using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
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
        if(other.gameObject.tag == "Tree")
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
        }
    }
    public void Attack()
    {
        animator.SetFloat("Speed", data.attackSpeed);
        for (int i = 0; i < trees.Count; i++)
        {
            trees[i].Hit(ax.damage);
            if(trees[i].isDeath)
            {
                Exit(trees[i]);
                i--;
            }

        }
    }
}

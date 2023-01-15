using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    
    Movement movement;
    [SerializeField] private Transform hand;
    [SerializeField] private Data data;
    public List<TreeBase> trees;
    Animator animator;
    public Ax ax;
    private void Awake()
    {
        //ax = AxManager.Instance.
    }
    private void OnEnable()
    {
        movement = GetComponent<Movement>();
        movement.onStop += CheckHit;
    }
    private void OnDisable()
    {
        movement.onStop -= CheckHit;
        
    }
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Speed", data.attackSpeed);
        ax = AxManager.Instance.InstantiateCurrentAx();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tree")
        {
            Enter(other.GetComponent<TreeBase>());
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            Exit(other.GetComponent<TreeBase>());

        }
    }
    public void Enter(TreeBase tree)
    {
        trees.Add(tree);
        if (trees.Count > 0)
        {
            animator.SetBool("Hit", true);
        }
    }
    public void Exit(TreeBase tree)
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
            trees[i].Hit(ax.axData.damage);
            if(trees[i].isDeath)
            {
                Exit(trees[i]);
                i--;
            }
        }
    }
    public void CheckHit()
    {
        if(trees.Count >=1)
        {
            animator.SetBool("Hit", true);
        }
    }
}

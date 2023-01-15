using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeManager : Singleton<TreeManager>
{
    [SerializeField] private GameObject teleport;
    public List<Tree> allTrees = new List<Tree>();
    private void Awake()
    {
        teleport = FindObjectOfType<Teleport>().gameObject;
        teleport.SetActive(false);
        allTrees = FindObjectsOfType<Tree>().Select(x => x).ToList();
        if(teleport == null)
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
    }
    public void CheckFinish()
    {
        if(allTrees.Count == 0)
        {
            teleport.SetActive(true);
        }
    }
}

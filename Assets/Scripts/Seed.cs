using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Seed : MonoBehaviour
{
    [SerializeField] private FarmTree tree;
    [SerializeField] private Transform farmTransform;
    TreeBase treeBase;
    private void Start()
    {
        treeBase = GetComponent<TreeBase>();
        if(tree.isUnLocked)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            SeedAnimaton();
        }
    }
    public void SeedAnimaton()
    {
        transform.DOJump(farmTransform.position, 10, 1, 3f).OnComplete(()=>
        {
            FarmManager.Instance.UnlockTree(tree.farmIndex);
            CameraFollow.instance.followObject = Movement.Instance.gameObject;
        });
        CameraFollow.instance.followObject = this.gameObject;
    }
}

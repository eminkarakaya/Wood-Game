using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Seed : MonoBehaviour
{
    public int index;
    [SerializeField] FarmTree tree;
    OnTheTree onTheTree;
    private void OnEnable()
    {
        onTheTree = GetComponent<OnTheTree>();
        onTheTree.onGround += TriggerEnable;
    }
    private void OnDisable()
    {
        onTheTree.onGround -= TriggerEnable;
        
    }
    private void Start()
    {
        tree = FarmManager.Instance.GetFarmTree(index);
        if(tree.isUnLocked)
        {

            Destroy(gameObject);
        }
        GetComponent<Collider>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            SeedAnimaton();
            GetComponent<Collider>().enabled = false;
        }
    }
    public void SeedAnimaton()
    {
        
        CameraFollow.instance.followObject = this.gameObject;
        Movement.Instance.isAnim = true;
        transform.DOJump(FarmManager.Instance.GetFarmPlace(tree.farmIndex), 10, 1, 3f).OnComplete(()=>
        {
            FarmManager.Instance.UnlockTree(tree.farmIndex);

            
            tree.ReviveAnim(() =>
            {
                CameraFollow.instance.followObject = Movement.Instance.gameObject;
                Destroy(this.gameObject);
                Movement.Instance.isAnim = false;
            });
        });
    }
    public void TriggerEnable()
    {
        GetComponent<Collider>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DropFromBagDestroy : MonoBehaviour
{
    public Transform shopTransform;
    public DropGold drop;
    public bool start;
    [SerializeField] public CollectableType collectableType;
    public DropPlaceBase dropMachine;
    private void Start()
    {
        dropMachine = GetComponent<DropPlaceBase>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Drop _drop))
        {
            var qwe = other.gameObject.AddComponent(typeof(DropFromBagDestroyAddComponent)) as DropFromBagDestroyAddComponent;
            qwe.dropFromBagDestroy = this;
            start = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Drop _drop))
        {
            start = false;
            Destroy(other.gameObject.GetComponent<DropFromBagDestroyAddComponent>());
            StopAllCoroutines();
        }
    }
    
    public void Jump(GameObject obj,Transform other)
    {
        obj.transform.DOJump(dropMachine.GetAvailablePlace(), 1, 1, 1f).OnComplete(() => {
            Destroy(obj.gameObject);
            drop.AddCollectable();
            });
    }
    public void Output(Transform other)
    {
        var obj = CollectManager.Instance.SpawnObject(dropMachine.GetAvailablePlace(), 2);
        obj.transform.DOJump(other.position, 1, 1, .3f).OnComplete(()=>ObjectPool.Instance.SetPooledObject(obj,2));
    }
}

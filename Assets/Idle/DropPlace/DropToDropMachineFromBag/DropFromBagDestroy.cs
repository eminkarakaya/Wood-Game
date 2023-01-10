using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DropFromBagDestroy : MonoBehaviour
{
    [SerializeField] private CollectableType collectableType;
    DropPlaceBase dropMachine;
    Drop drop;
    private void Start()
    {
        dropMachine = GetComponent<DropPlaceBase>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            drop = other.GetComponent<Drop>();
            StartCoroutine(Fill(other.transform));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
    IEnumerator Fill(Transform other)
    {
        while (true)
        {
            yield return new WaitForSeconds(dropMachine.time);
            var collectable = drop.DropItem(collectableType);
            if (collectable != null)
            {
                var obj = collectable.gameObject;
                Jump(obj,other);
                dropMachine.SetCurrent(+1);
                GameManager.Instance.SetWood(-1);
                
            }
        }
    }
    public void Jump(GameObject obj,Transform other)
    {
        obj.transform.DOJump(dropMachine.GetAvailablePlace(), 1, 1, 1f).OnComplete(() => {
            ObjectPool.Instance.SetPooledObject(obj, ObjectPool.Instance.Wood);
            Output(other);
            });
    }
    public void Output(Transform other)
    {
        var obj = CollectManager.Instance.SpawnObject(dropMachine.GetAvailablePlace(), 2);
        obj.transform.DOJump(other.position, 1, 1, .3f).OnComplete(()=>ObjectPool.Instance.SetPooledObject(obj,2));
    }
}

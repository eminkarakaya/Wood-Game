using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropToDropMachineFromBag : MonoBehaviour
{
    [SerializeField] private CollectableType collectableType;
    DropMachine dropMachine;
    Drop drop;
    private void Start()
    {
        dropMachine = GetComponent<DropMachine>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            drop = other.GetComponent<Drop>();
            StartCoroutine(Fill());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
    IEnumerator Fill()
    {

        while (true)
        {
            if (dropMachine.IsFull())
            {
                yield return null;

            }
            else
            {
                yield return new WaitForSeconds(dropMachine.time);
                var collectable = drop.DropItem(collectableType);
                if(collectable != null)
                {
                    var obj = collectable.gameObject;
                    dropMachine.AddCollectable(obj);
                    Jump(obj);
                    dropMachine.SetCurrent(+1);
                    GameManager.Instance.SetWood(-1);
                }


            }
        }
        // dolunca olcaklar

    }
    public void Jump(GameObject obj)
    {
        obj.transform.DOJump(dropMachine.GetAvailablePlace(), 1, 1, 1f)/*.OnComplete(() => ObjectPool.Instance.SetPooledObject(obj, ObjectPool.Instance.Wood))*/;
        Debug.Log(dropMachine);
    }
}

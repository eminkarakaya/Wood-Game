using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropToDropMachineFromGMDestroy : MonoBehaviour
{
    [SerializeField] DropPlaceBase dropMachine;
    Transform _other;
    private void Start()
    {
        dropMachine = GetComponent<DropPlaceBase>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _other = other.transform;
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
                dropMachine.SetCurrent(+1);
                //GameManager.Instance.SetWood(-1);

                var obj = CollectManager.Instance.SpawnObject(_other.position, ObjectPool.Instance.Wood);

                Jump(obj);

            }
        }
        // dolunca olcaklar

    }
    public void Jump(GameObject obj)
    {
        obj.transform.DOJump(dropMachine.GetAvailablePlace(), 1, 1, 1f).OnComplete(() => ObjectPool.Instance.SetPooledObject(obj, ObjectPool.Instance.Wood));
    }
}

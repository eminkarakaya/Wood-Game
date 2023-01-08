using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Collect : MonoBehaviour
{
    [SerializeField] private int _bagCapacity;
    [SerializeField] private List<Collectable> _collectedItems;
    [SerializeField] private Transform _bagTransform;
    [SerializeField] private TextMeshPro maxText;
    [SerializeField] private float currentBagHeight;
    private void Start()
    {
        currentBagHeight = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            CollectItem(other.gameObject.GetComponent<Collectable>());
        }
    }
    private void CollectItem(Collectable collectable)
    {
        if (_collectedItems.Count < _bagCapacity)
        {
            collectable.transform.SetParent(_bagTransform);
            if (_collectedItems.Count == 0)
            {
                collectable.transform.DOLocalJump(new Vector3(0, currentBagHeight, 0), .5f + currentBagHeight, 1, 1f);
                currentBagHeight += collectable.height;
            }
            else
            {

                //collectable.transform.DOLocalMove(Vector3.zero, 1f);
                collectable.transform.DOLocalJump(new Vector3(0,currentBagHeight,0),.5f+currentBagHeight,1, 1f);
                currentBagHeight += collectable.height;
                //collectable.transform.position = _collectedItems[_collectedItems.Count - 1].topTransform.position;
            }
            collectable.transform.forward = this.transform.forward;
            collectable.tag = "Untagged";
            _collectedItems.Add(collectable);
            collectable.GetComponent<Collider>().enabled = false;
            collectable.transform.localRotation = Quaternion.Euler(Vector3.zero);
            
            if (_collectedItems.Count >= _bagCapacity)
            {
                maxText.transform.position = _collectedItems[_collectedItems.Count - 1].transform.position + Vector3.up;
                maxText.enabled = true;
                return;
            }
        }
    }
    public List<Collectable> GetCollectableObjects()
    {
        return _collectedItems;
    }
    public void DropItem(CollectableType collectableType,out Collectable collectable)
    {
        if (_collectedItems.Count >= 0)
        {
            foreach (var item in _collectedItems)
            {
                if(item.type == collectableType)
                {
                    item.transform.SetParent(null);
                    _collectedItems.Remove(item);
                    collectable = item;
                    break;
                }
            }
        }
        collectable = null;
    }
    //private IEnumerator DropItem(Collectable collectable)
    //{

    //    if (_collectedItems.Count >= 0)
    //    {
    //        collectable.transform.SetParent(null);
    //        collectable.transform.SetParent(null);
    //    }
    //}


}

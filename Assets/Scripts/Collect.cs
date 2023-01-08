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
    public void SetCurrentBagHeight(float value)
    {
        currentBagHeight -= value;
    }
    public void SetBagPos()
    {
        currentBagHeight = 0;
        for (int i = 0; i < _collectedItems.Count; i++)
        {
            _collectedItems[i].transform.DOLocalJump(new Vector3(0, currentBagHeight, 0), .5f + currentBagHeight, 1, 0f);
            currentBagHeight += _collectedItems[i].height;
        }
    }
    private void CollectItem(Collectable collectable)
    {
        if (_collectedItems.Count < _bagCapacity)
        {
            collectable.transform.SetParent(_bagTransform);
           

            //collectable.transform.DOLocalMove(Vector3.zero, 1f);
            collectable.transform.DOLocalJump(new Vector3(0,currentBagHeight,0),.5f+currentBagHeight,1, 1f).OnComplete(()=>
            {
                _collectedItems.Add(collectable);
            });
            currentBagHeight += collectable.height;
            //collectable.transform.position = _collectedItems[_collectedItems.Count - 1].topTransform.position;
            collectable.tag = "Untagged";
            
            collectable.transform.forward = this.transform.forward;
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
    public void ToggleText(bool value)
    {
        maxText.enabled = value;
    }
    public List<Collectable> GetCollectableObjects()
    {
        return _collectedItems;
    }
    public List<Collectable> GetUpperCollectableObjects(Collectable collectable,List<Collectable> collectables)
    {
        List<Collectable> tempCollectables = new List<Collectable>();
        int temp = 0;
        for (int i = 0; i < collectables.Count; i++)
        {
            if(collectables[i] == collectable)
            {
                
                if (collectables.Count >= i + 1) 
                {
                    temp = i+1;
                }
                break;
            }
        }
        for (int i =  collectables.Count -(collectables.Count- temp); i < collectables.Count ; i++)
        {
            tempCollectables.Add(collectables[i]);
        }
        return tempCollectables;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Drop : MonoBehaviour
{
    
    Collect collect;
    private void Start()
    {
        collect = GetComponent<Collect>();
    }
    public Collectable DropItem(CollectableType collectableType)
    {
        if (collect.GetCollectableObjects().Count >= 0)
        {
            for (int i = collect.GetCollectableObjects().Count-1; i >= 0; i--)
            {
                if (collect.GetCollectableObjects()[i].type == collectableType)
                {
                    var item = collect.GetCollectableObjects()[i];
                    item.GetComponent<Collider>().enabled = false;
                    item.transform.SetParent(null);
                    item.transform.rotation = Quaternion.Euler(Vector3.zero);
                    collect.SetCurrentBagHeight(item.height);
                    for (int j = 0; j < collect.GetUpperCollectableObjects(item, collect.GetCollectableObjects()).Count; j++)
                    {
                        var obj = collect.GetUpperCollectableObjects(item, collect.GetCollectableObjects())[j];
                        float offsett = obj.transform.localPosition.y;
                        Debug.Log(obj,obj);
                        obj.transform.DOLocalMoveY(offsett - obj.height, 0f);
                    }
                    collect.ToggleText(false);
                    collect.GetCollectableObjects().Remove(item);
                    return item;
                }
            }
           
        }
        return null;
    }
}

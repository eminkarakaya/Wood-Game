using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DropGold : MonoBehaviour
{
    public bool isFull;
    public Transform machineTransform;
    public Transform [] transforms;
    public List<DropData> dropDatas = new List<DropData>();
    private void Awake()
    {
        
    }
    private void Start()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            DropData dropData = new DropData();
            dropDatas.Add(dropData);
            dropData._transform = transforms[i].position;
        }
    }

  
    public DropData GetAvailablePlace()
    {
        foreach (var item in dropDatas)
        {
            if(item.gold == null)
            {
                return item;
            }
        }
        isFull = true;
        return null;
    }
    public void AddCollectable()
    {
        var place = GetAvailablePlace();
        if(place != null)
        {
            var obj = Instantiate(GameManager.Instance.goldPrefab);
            obj.transform.position = machineTransform.position;
            obj.transform.DOJump(place._transform, 1, 1, .2f);
            place.gold = obj.GetComponent<Gold>();
        }
    }
}
[System.Serializable]
public class DropData
{
    public Vector3 _transform;
    public Gold gold;
    public DropData()
    {
        _transform = Vector3.zero;
        gold = null;
    }
}

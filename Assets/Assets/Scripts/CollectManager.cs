
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectManager : Singleton<CollectManager>
{
    public Transform baseTransform;
    public Transform farmBaseTransform;
    public GameObject SpawnObject(Vector3 spawnPos,int objPoolIndex)
    {
        var obj = ObjectPool.Instance.GetPooledObject(objPoolIndex);
        obj.transform.position = spawnPos;
        return obj;
    }
    
}

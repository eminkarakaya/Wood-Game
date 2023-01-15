using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropMachine : DropPlaceBase
{
    public delegate void OnEmpty();
    public delegate void OnWork();
    public OnEmpty onEmpty;
    public OnWork onWork;
    public List<GameObject> collectables;
    public List<Transform> transforms;
    public float collectPlaceHeight;
    public int line;
    public Transform dropPos;
   
    public void AddCollectable(GameObject collectable)
    {
        collectables.Add(collectable);
        line++;
        if (line == transforms.Count+1)
        {
            line = 1;
            collectPlaceHeight += collectable.GetComponent<Collectable>().height;
        }
        if(collectables.Count == 1)
        {
            onWork?.Invoke();
        }
    }
    public void RemoveCollectable(GameObject collectable)
    {
        collectables.Remove(collectable);
        line++;
        if (line == 0)
        {
            line = transforms.Count;
            collectPlaceHeight += collectable.GetComponent<Collectable>().height;
        }
        if(collectables.Count == 0)
        {
            onEmpty?.Invoke();
        }
    }
    public override Vector3 GetAvailablePlace()
    {
        Debug.Log(transforms.Count);
        Debug.Log(transforms[line - 1], transforms[line - 1]);
        return new Vector3(transforms[line - 1].position.x, collectPlaceHeight, transforms[line - 1].position.z);
    }
    public GameObject GetLastCollectable()
    {
        if(collectables.Count == 0)
        {
            return null;
        }
        var collectable = collectables[collectables.Count - 1];
        RemoveCollectable(collectables[collectables.Count - 1]);
        return collectable;

    }
}

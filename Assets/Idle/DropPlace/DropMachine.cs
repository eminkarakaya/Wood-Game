using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropMachine : DropPlaceBase
{
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
            collectPlaceHeight += .3f;
        }
    }
    public void RemoveCollectable(GameObject collectable)
    {
        collectables.Remove(collectable);
        line++;
        if (line == 0)
        {
            line = transforms.Count;
            collectPlaceHeight -= .3f;
        }
    }
    public override Vector3 GetAvailablePlace()
    {
        return new Vector3(transforms[line - 1].position.x, collectPlaceHeight, transforms[line - 1].position.z);
    }
}

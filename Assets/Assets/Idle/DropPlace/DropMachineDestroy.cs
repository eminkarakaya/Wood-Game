using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DropMachineDestroy : DropPlaceBase
{
    public Transform dropPos;
    public override Vector3 GetAvailablePlace()
    {
        return dropPos.position;
    }
}

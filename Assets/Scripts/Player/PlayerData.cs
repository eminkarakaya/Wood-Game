using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/PlayerData")]
public class PlayerData : Data
{
    void Start()
    {
        if(GameManager.Instance.resetData)
        {
            moveSpeed = defaultMove;
            attackSpeed = defaultAttack;
            bagCapacity = defaultBag;
        }              
    }
}

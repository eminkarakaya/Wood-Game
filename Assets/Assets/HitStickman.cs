using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStickman : MonoBehaviour
{
    Hit hit;
    private void Start()
    {
        hit = GetComponentInParent<Hit>();

    }
    public void Attack()
    {
        hit.Attack();
    }
}

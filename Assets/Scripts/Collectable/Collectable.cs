using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    CLOTH,
    METAL,
    WOOD
}
public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Transform topTransform;
    public float height;
    private void Start()
    {
        height = Mathf.Abs( transform.position.y - topTransform.position.y);
    }
}

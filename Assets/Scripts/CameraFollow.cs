using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    
    public static CameraFollow instance;
    public GameObject followObject;
    [SerializeField] Vector3 offset;
    public bool isAnimation;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
    }
    private void LateUpdate()
    {
        Follow();
    }
    void Follow()
    {
        
        if(followObject !=null)
            transform.position = Vector3.Lerp(transform.position, followObject.transform.position + offset, .5f);
        else
        {
            if(Movement.Instance !=null)
                followObject = Movement.Instance.gameObject;
        }
    }
}
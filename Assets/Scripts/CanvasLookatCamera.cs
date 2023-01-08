using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLookatCamera : MonoBehaviour
{
    Transform cam;
    void Start()
    {
        cam = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
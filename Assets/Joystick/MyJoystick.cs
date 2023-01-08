using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyJoystick : MonoBehaviour
{
    public bool moved = false; 
    public static MyJoystick instance;
    [SerializeField] RectTransform center, knob;
    [SerializeField] float range;
    [SerializeField] bool fixedJoystick;
    [HideInInspector] public Vector2 dir;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        
        Vector2 pos = Input.mousePosition;
        if(Input.GetMouseButtonDown(0))
        {
            center.position = pos;
            knob.position = pos;
            ShowHide(true);
            moved = true;
        }
        else if(Input.GetMouseButton(0))
        {
            knob.position = pos;
            knob.position = center.position + Vector3.ClampMagnitude(knob.position - center.position, center.sizeDelta.x * range);
            if(knob.position != Input.mousePosition && !fixedJoystick)
            {
                Vector3 outsideBoundsVector = Input.mousePosition - knob.position;
                center.position += outsideBoundsVector;
            }
            dir = (knob.position - center.position).normalized;
        }
        else
        {
            dir = Vector3.zero;
            ShowHide(false);
            moved = false;
        }

    }
    void ShowHide(bool state)
    {
        center.gameObject.SetActive(state);
        knob.gameObject.SetActive(state);
    }
}

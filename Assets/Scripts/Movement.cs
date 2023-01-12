using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Data playerData;
    Rigidbody rb;
    private Animator _anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {

        if (MyJoystick.instance.moved)
        {
            rb.velocity = (Vector3.right * MyJoystick.instance.dir.x + Vector3.forward * MyJoystick.instance.dir.y) * playerData.moveSpeed;
            transform.forward = new Vector3(MyJoystick.instance.dir.x, 0, MyJoystick.instance.dir.y) * (Time.deltaTime * playerData.moveSpeed);
            _anim.SetBool("Move", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            _anim.SetBool("Move", false);
        }
    }
}
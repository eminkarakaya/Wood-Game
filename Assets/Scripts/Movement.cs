using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] LayerMask layer;
    private Transform _player;
    [SerializeField] public float speed;
    private Animator _anim;
    RaycastHit hit;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _player = transform.GetChild(0);
        _anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        //Physics.Raycast(_player.position + _player.forward / 3 + _player.transform.up, -_player.up, out hit, 100, layer);
        //Debug.DrawRay(_player.position + _player.forward / 3 + _player.transform.up, -_player.up * 5);
        if (MyJoystick.instance.moved)
        {
            //if (hit.collider != null)
            //{
                rb.velocity = (Vector3.right * MyJoystick.instance.dir.x + Vector3.forward * MyJoystick.instance.dir.y) * speed;
                //transform.position += (Vector3.right * MyJoystick.instance.dir.x + Vector3.forward * MyJoystick.instance.dir.y) * (Time.deltaTime * speed);

            //}
            transform.forward = new Vector3(MyJoystick.instance.dir.x, 0, MyJoystick.instance.dir.y) * (Time.deltaTime * speed);
            _anim.SetBool("Move", true);
            //_anim.SetBool("Idle", false);
        }
        else
        {
            rb.velocity = Vector3.zero;
            _anim.SetBool("Move", false);
            //_anim.SetBool("Run", false);
            //_anim.SetBool("Idle", true);

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxTrigger : MonoBehaviour
{
    Ax ax;
    OnTheTree onTheTree;

    private void OnEnable()
    {
        onTheTree = GetComponent<OnTheTree>();
        onTheTree.onGround += EnableTrigger;
    }
    private void OnDisable()
    {
        onTheTree.onGround -= EnableTrigger;
    }
    
    private void Start()
    {
        GetComponent<Collider>().enabled = false;
        ax = GetComponent<Ax>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            GetComponent<Collider>().enabled = false;
            AxManager.Instance.ChangeAx(ax);
            Destroy(this);
        }
    }
    public void EnableTrigger()
    {
        GetComponent<Collider>().enabled = true;
    }
}

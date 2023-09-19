using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUpgradeCanvas : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private void Start()
    {
        canvas.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canvas.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUpgradeCanvas : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
}

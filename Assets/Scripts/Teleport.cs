using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            LevelManager.Instance.NextLevel();
            Debug.Log("next");
        }
    }
}

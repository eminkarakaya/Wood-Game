using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("level")+1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public int currentScene = 1;
    private void Awake() {
        
        DontDestroyOnLoad(gameObject);
    }
    private IEnumerator Start()
    {
        if(PlayerPrefs.HasKey("Level"))
        {
            currentScene = PlayerPrefs.GetInt("Level");
            if(currentScene == 0)
                currentScene = 1;
        }
        else
        {
            currentScene = 1;
        }
        
        AsyncOperation ao = SceneManager.LoadSceneAsync(currentScene);
        while (!ao.isDone)
        {
            yield return null;
        }
        
        SceneManager.LoadScene(currentScene);
    }
    private void OnApplicationQuit() {
        
        // if(LevelManager.Instance != null)
        // {
        //     currentScene = LevelManager.Instance.level;
        // }
        PlayerPrefs.SetInt("Level",currentScene);
    }
}

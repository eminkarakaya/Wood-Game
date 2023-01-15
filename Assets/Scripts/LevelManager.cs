using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject player;
    public int level;
    private Image fader;
    public Transform spawnPoint;
    private void OnEnable()
    {
        LoadData();
        StartCoroutine(FadeScene(level, 1, .2f));
    }
    private void OnDisable()
    {
        SaveData();   
    }

    void Awake()
    {
        LevelManager[] objs = GameObject.FindObjectsOfType<LevelManager>();
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadData()
    {
        level = PlayerPrefs.GetInt("Level");
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("Level", level);
    }
    private void Start()
    {
        Instantiate(player,spawnPoint.position,Quaternion.identity);
    }
    public IEnumerator FadeScene(int level, float duration, float waitTime)
    {
        yield return new WaitForSeconds(1);
        //fader.transform.position = Vector3.zero;
        float passed = 0f;
        fader = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        fader.gameObject.SetActive(true);
        while (passed < duration)
        {
            passed += Time.deltaTime;
            fader.color = new Color(0, 0, 0, 1 );
            //fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, passed));
            yield return null;
        }
        AsyncOperation ao = SceneManager.LoadSceneAsync(level);
        while (!ao.isDone)
        {
            yield return null;
        }
        SceneManager.LoadScene(level);
        yield return new WaitForSeconds(waitTime);
        passed = 0;
        fader = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        fader.color = new Color(0, 0, 0, 1);
        fader.gameObject.SetActive(false);
        while (passed < duration)
        {
            passed += Time.deltaTime;
            //fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, passed));
            yield return null;
        }
        Instantiate(player, spawnPoint.position, Quaternion.identity);
    }
    public void NextLevel()
    {
        level++;
        if (level >= SceneManager.sceneCountInBuildSettings -1)
        {
            level = 0;
        }
        StartCoroutine(FadeScene(level, 1f, .5f));
    }
}

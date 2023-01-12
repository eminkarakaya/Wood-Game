using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Stroage Config")]
    [SerializeField] private string fileName;
    private FileDataHandler dataHandler;
    GameData gameData;
    public static DataPersistenceManager instance { get; private set; }

    private List<IDataPersistence> dataPersistenceObjects;
    void Awake()
    {
        instance = this;
    }
    void OnEnable()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllIDataPersistenceObjects();
        Debug.Log("Loaded");
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("Data bulunamadý");
            NewGame();
        }

        foreach (IDataPersistence dataPersistanceObject in dataPersistenceObjects)
        {
            dataPersistanceObject.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistanceObject in dataPersistenceObjects)
        {
            dataPersistanceObject.SaveData(gameData);
        }
        dataHandler.Save(gameData);
    }
    void OnApplicationQuit()
    {
        Debug.Log("Saved");
        SaveGame();
    }
    List<IDataPersistence> FindAllIDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
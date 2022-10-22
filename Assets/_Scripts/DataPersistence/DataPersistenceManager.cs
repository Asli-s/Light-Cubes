using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Globalization;
using UnityEngine.Rendering;

public class DataPersistenceManager : MonoBehaviour

{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    // Start is called before the first frame update
    private GameData gameData;
    private FileDataHandler dataHandler;

    private List<IDataPersistence> dataPersistenceObjects;

    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
          /*  Debug.LogError("already an instance created");
            Destroy(Instance);
            //*/
        Instance = this;
        }


        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }


    private void Start()
    {
      
    }



    public void NewGame()
    {
        this.gameData = new GameData();

    }



    public void LoadGame()
    {

        this.gameData = dataHandler?.Load();

        if (this.gameData == null)
        {
            Debug.Log("no game to load, create new game");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects ?? new List<IDataPersistence> { null })
        {
            dataPersistenceObject?.LoadData(gameData);
        }

        print("level" + gameData.level);
        print("level" + gameData.playerPosition);

    }


    public void SaveGame()
    {
        foreach (IDataPersistence dataPers in dataPersistenceObjects)
        {
            dataPers.SaveData(gameData);
        }

        print("saved level" + gameData.level);
        print("saved pos" + gameData.playerPosition);

        print("saved sound" + gameData.sound);
        dataHandler.Save(gameData);

    }


    private void OnApplicationQuit()
    {
     
        SaveGame();
    }
    public void changeScene()
    {
        SaveGame();
    }
    private void OnApplicationPause(bool pause)
    {
       /* if (pause)
        {
          
            SaveGame();
       
      

        }
        else
        {
           
            DataPersistenceManager.Instance.LoadGame();
         


        }*/
    }






    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }



}

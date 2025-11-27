using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public static SavingManager instance;
    
    /* [SerializeField]*/ private string fileName = "Mevious.data";

    private GameData gameData;
    private List<ISavingManager> savingManagers = new List<ISavingManager>();
    private FileDataHandler dataHandler;
    

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        savingManagers = FindAllSavingManagers();
        
        LoadGame();
    }


    public void NewGame()
    {
        gameData = new GameData();
    }

    [ContextMenu("Delete Saved File")]
    public void ClearSavedData()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataHandler.Delete();
    }

    public void LoadGame()
    {
        gameData = dataHandler.Load();

        if (this.gameData == null)
        {
            Debug.Log("No saved data found");
            NewGame();
        }

        foreach (ISavingManager savingManager in savingManagers)
        {
            savingManager.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        // data handler save gameData
        foreach (ISavingManager savingManager in savingManagers)
        {
            savingManager.SaveData(ref gameData);
        }
        
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<ISavingManager> FindAllSavingManagers()
    {
        IEnumerable<ISavingManager> savingManagers = FindObjectsOfType<MonoBehaviour>(true).OfType<ISavingManager>();
        
        return new List<ISavingManager>(savingManagers);
    }
}

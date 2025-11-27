using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour, ISavingManager
{
    public static SceneManager instance;
    
    [SerializeField] private int currentScene; 

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        // Debug.Log(currentScene);
    }

    public void myStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.buttonClickSfx);
    }

    public void myMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.buttonClickSfx);
    }

    public void myLoadScene(int levelIndex, Vector2 position)
    {
        StartCoroutine(LoadSceneCoroutine(levelIndex, position));
    }

    private IEnumerator LoadSceneCoroutine(int levelIndex, Vector2 position)
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.buttonClickSfx);
    
        // load the scene one by one
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelIndex);
    
        // wait for the scene fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    
        // wait a fame to unsure all subjects initialized
        yield return null;
    
        // now can safely set the player
        PlayerManager.instance.player.transform.position = new Vector3(position.x, position.y, 0);
        PlayerManager.instance.setUnmoveableTimer(0.1f);
    
        // set player's state due to grounded state
        if (PlayerManager.instance.player.IsGroundDetected())
        {
            PlayerManager.instance.player.stateMachine.ChangeState(PlayerManager.instance.player.idleState);
        }
        else
        {
            PlayerManager.instance.player.stateMachine.ChangeState(PlayerManager.instance.player.idleState);
        }
    
        // change current scene index
        currentScene = levelIndex;
    }

    public void myDeleteData()
    {
        SavingManager.instance.ClearSavedData();
    }

    
    public void LoadData(GameData _data)
    {
        foreach (KeyValuePair<string,int> pair in _data.inventory)
        {
            if (pair.Key == "CurrentScene")
            {
                currentScene = pair.Value;
            }
        }
        if (currentScene == 0)
            currentScene = 1;
    }

    public void SaveData(ref GameData _data)
    {
        // _data.inventory.Clear();
        
        _data.inventory.Add("CurrentScene", currentScene);
    }
}

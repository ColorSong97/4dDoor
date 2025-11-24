using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceManager : MonoBehaviour
{
    public static ScenceManager instance;

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

    public void myLoadScence(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.buttonClickSfx);
    }

}

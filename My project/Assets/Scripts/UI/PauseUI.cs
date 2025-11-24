using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    private bool isOpen = false;
    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrContinue();
            AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
            
        }
    }

    public void PauseOrContinue()
    {
        isOpen = !isOpen;
        AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
        if(isOpen)
        {
            AudioManager.Instance.PlayBgm();
        }
        else
        {
            AudioManager.Instance.PauseBgm();
        }
        Time.timeScale = isOpen ? 0f : 1f;
        pauseUI.SetActive(isOpen);
    }
}

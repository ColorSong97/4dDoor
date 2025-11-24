using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioUI : MonoBehaviour
{
    [SerializeField] private GameObject audioUi;
    private bool isOpenUi;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider masterSlider;
    //[SerializeField] private Slider bgmSlider;
    private void Start()
    {
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&isOpenUi)
        {
           CloseUI();
        }
    }



    public void CloseUI()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
        isOpenUi = false;
        audioUi.SetActive(isOpenUi);
    }

    public void OpenUI()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
        isOpenUi= true;
        audioUi.SetActive(isOpenUi);
    }
   
    public void SetSfxVolume(float value)
    {
       float db=value>0 ? 20*Mathf.Log10(value) : -80;
       mixer.SetFloat("Sfx", db);
       AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
    }
    public void SetBgmVolume(float value)
    {
        float db = value > 0 ? 20 * Mathf.Log10(value) : -80;
        mixer.SetFloat("Bgm", db);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
    }
    public void SetMasterVolume(float value)
    {
        float db = value > 0 ? 20 * Mathf.Log10(value) : -80;
        mixer.SetFloat("Master", db);
        AudioManager.Instance.PlaySfx(AudioManager.Instance.pauseSfx);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("AudioGroup")]
    public AudioMixerGroup bgmGroup;
    public AudioMixerGroup sfxGroup;

    
    [Header("audioSource")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("audioClip")]
    public AudioClip defaultbgm;
    public AudioClip pauseSfx;
    public AudioClip buttonClickSfx;
    public AudioClip jumpSfx;
    public AudioClip DashSfx;
    public AudioClip DeathSfx;
    public AudioClip SpaceDoorSkillSfx;
    public AudioClip CloneSkillSfx;
    public AudioClip SkillReadySfx;//冷却结束提示音
    public AudioClip GainSkillSfx;

    public bool isBgmPlay;
    private void Awake()//简单的单例实现
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        Init();
    }
    private void Init()
    {
        bgmSource.loop = true;
        bgmSource.outputAudioMixerGroup = bgmGroup;
        bgmSource.playOnAwake = true;

        sfxSource.loop = false;
        sfxSource.outputAudioMixerGroup = sfxGroup;
        sfxSource.playOnAwake = false;

        isBgmPlay = true;
    }
    private void Start()
    {
        bgmSource.Play();
    }
    public void PlayBgm()
    {
        if (!isBgmPlay)
        {
            isBgmPlay = !isBgmPlay;
            bgmSource.Play();
        }
    }
   
    public void PauseBgm()
    {
        if (isBgmPlay)
        {
            isBgmPlay = !isBgmPlay;
            bgmSource.Pause();
        }
    }
    public void StopBgm()
    {
        if (isBgmPlay)
        {
            isBgmPlay = false;
            bgmSource.Stop();
        }
    }
    public void PlaySfx(AudioClip sfxClip)
    {
        if (sfxClip == null) return;
        sfxSource.PlayOneShot(sfxClip);
    }

}

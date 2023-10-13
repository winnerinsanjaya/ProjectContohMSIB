using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;

    [SerializeField]
    private AudioSource sfxAudioSource;

    [SerializeField]
    private AudioSource bgmAudioSource;


    [SerializeField]
    private List<AudioClip> sfxClip;

    [SerializeField]
    private List<AudioClip> bgmClip;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;

        }


        instance = this;
        DontDestroyOnLoad(this.gameObject);

    }


    private void Start()
    {
        GetSavedVolume();
    }


    public void PlayBGM(int index)
    {
        if(bgmAudioSource.clip != null)
        {
            bgmAudioSource.Stop();
        }
        bgmAudioSource.clip = bgmClip[index];
        bgmAudioSource.Play();
    }


    public void PlaySFX(int index)
    {
        if (sfxAudioSource.clip != null)
        {
            sfxAudioSource.Stop();
        }
        sfxAudioSource.clip = sfxClip[index];
        sfxAudioSource.Play();
    }

    public void ChangeSfxVolume(float volume)
    {
        sfxAudioSource.volume = volume;

        PlayerPrefs.SetFloat("sfxVol", volume);
    } 
    
    public void ChangeBgmVolume(float volume)
    {
        bgmAudioSource.volume = volume;

        PlayerPrefs.SetFloat("bgmVol", volume);
    }

    private void GetSavedVolume()
    {
        if (PlayerPrefs.HasKey("bgmVol"))
        {
            bgmAudioSource.volume = PlayerPrefs.GetFloat("bgmVol");
        }

        if (!PlayerPrefs.HasKey("bgmVol"))
        {
            PlayerPrefs.SetFloat("bgmVol", bgmAudioSource.volume);
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            sfxAudioSource.volume = PlayerPrefs.GetFloat("sfxVol");
        }

        if (!PlayerPrefs.HasKey("sfxVol"))
        {
            PlayerPrefs.SetFloat("sfxVol", sfxAudioSource.volume);
        }
    }
}

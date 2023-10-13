using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayButton : MonoBehaviour
{

    [SerializeField]
    private GameObject PauseScreen;

    [SerializeField]
    private GameObject PlayScreen;

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider bgmSlider;

    private void Awake()
    {
        sfxSlider.onValueChanged.AddListener(this.OnSfxChanged);
        bgmSlider.onValueChanged.AddListener(this.OnBgmChanged);
    }
    public void PauseGame()
    {

        PlayButtonSound();
        Time.timeScale = 0;
        PlayScreen.SetActive(false);
        PauseScreen.SetActive(true);

        if (PlayerPrefs.HasKey("bgmVol"))
        {
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
        }

        if (PlayerPrefs.HasKey("sfxVol"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        }
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PlayScreen.SetActive(true);
        PauseScreen.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        PlayButtonSound();
        SceneManager.LoadScene("MainMenu");
    }

    private void OnSfxChanged(float value)
    {
        PlayButtonSound();
        AudioPlayer.instance.ChangeSfxVolume(value);
    }
    private void OnBgmChanged(float value)
    {
        PlayButtonSound();
        AudioPlayer.instance.ChangeBgmVolume(value);
    }


    public void PlayButtonSound()
    {
        AudioPlayer.instance.PlaySFX(3);
    }
}

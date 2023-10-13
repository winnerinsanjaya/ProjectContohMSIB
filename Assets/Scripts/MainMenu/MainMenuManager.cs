using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    private Slider sfxSlider;

    [SerializeField]
    private Slider bgmSlider;

    [SerializeField]
    private GameObject mainMenuContainer;


    [SerializeField]
    private GameObject optionContainer;

    private void Awake()
    {
        sfxSlider.onValueChanged.AddListener(this.OnSfxChanged);
        bgmSlider.onValueChanged.AddListener(this.OnBgmChanged);
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer.instance.PlayBGM(0);
    }


    public void LoadGameplay(string targetScene)
    {
        PlayerPrefs.SetInt("playerHealth", 3);
        SceneManager.LoadScene(targetScene);
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

    public void OpenMainMenu()
    {
        PlayButtonSound();
        mainMenuContainer.SetActive(true);
        optionContainer.SetActive(false);
    }

    public void OpenOption()
    {
        PlayButtonSound();
        mainMenuContainer.SetActive(false);
        optionContainer.SetActive(true);

        if (PlayerPrefs.HasKey("bgmVol"))
        {
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVol");
        }
        
        if (PlayerPrefs.HasKey("sfxVol"))
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol");
        }
    }


    public void PlayButtonSound()
    {
        AudioPlayer.instance.PlaySFX(3);
    }
}

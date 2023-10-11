using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayButton : MonoBehaviour
{

    [SerializeField]
    private GameObject PauseScreen;

    [SerializeField]
    private GameObject PlayScreen;
    public void PauseGame()
    {
        Time.timeScale = 0;
        PlayScreen.SetActive(false);
        PauseScreen.SetActive(true);
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
        SceneManager.LoadScene("MainMenu");
    }
}

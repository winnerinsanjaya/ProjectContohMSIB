using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("playerHealth"))
        {
            playerHealth = PlayerPrefs.GetInt("playerHealth");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealth();
    }

    private void UpdatePlayerHealth()
    {

        float health = playerHealth;
        float dividedBy = 3.0f;
        float fillAmount = health / dividedBy;
        healthBar.fillAmount = fillAmount;
        GameManager.instance.SetHealthObj(playerHealth);

    }


    public void SetHealth(int amt)
    {

        if(amt < 0)
        {
            AudioPlayer.instance.PlaySFX(2);
        }
        if(playerHealth <= 3 && playerHealth >= 0)
        {
            playerHealth += amt;
            PlayerPrefs.SetInt("playerHealth", playerHealth);

            if (playerHealth > 3)
            {
                playerHealth = 3;
            }
        }

        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}

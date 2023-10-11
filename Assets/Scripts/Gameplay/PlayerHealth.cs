using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealth();
    }

    private void UpdatePlayerHealth()
    {
        float divider = 3;
        float health = playerHealth;
        float fillAmount = health / divider;
        healthBar.fillAmount = fillAmount;
        GameManager.instance.SetHealthObj(playerHealth);

    }


    public void SetHealth(int amt)
    {
        if(playerHealth <= 3 && playerHealth >= 0)
        {
            playerHealth += amt;

            if(playerHealth > 3)
            {
                playerHealth = 3;
            }
        }
        
    }
}

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
        float fillAmount = playerHealth / 3;
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

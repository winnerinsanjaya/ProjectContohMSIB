using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    // public GameManager gameManager;

    [SerializeField]
    private int coinID;

    private void Start()
    {
        // gameManager = FindObjectOfType<GameManager>();
        CheckCoinID();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Coin Diambil");
            //gameManager.AddCoin(1);


            //instance
            GameManager.instance.AddCoin(1);
            SetCoinState(0);
            Destroy(gameObject);
        }
    }

    private void CheckCoinID()
    {
        string scenename = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey(scenename + coinID))
        {
            int coinState = PlayerPrefs.GetInt(scenename + coinID);

            if(coinState == 0)
            {
                Destroy(this.gameObject);
                return;
            }
            if(coinState == 1)
            {
                //do nothing
                return;
            }
        }
        
        if (!PlayerPrefs.HasKey(scenename + coinID))
        {
            SetCoinState(1);
        }
    }

    private void SetCoinState(int state)
    {
        string scenename = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(scenename + coinID, state);
    }
}

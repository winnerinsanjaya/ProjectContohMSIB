using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour
{
    // public GameManager gameManager;

    [SerializeField]
    private int coinID;


    private string scenename;

    private string prefsName;

    private void Start()
    {
        scenename = SceneManager.GetActiveScene().name;

        prefsName = scenename + coinID;
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
            AudioPlayer.instance.PlaySFX(1);



            Destroy(gameObject);

        }
    }

    private void CheckCoinID()
    {

        if (PlayerPrefs.HasKey(prefsName))
        {
            int coinState = PlayerPrefs.GetInt(prefsName);

            if(coinState == 0)
            {
                CheckCoinScene(0);
                Destroy(this.gameObject);
                return;
            }
            if(coinState == 1)
            {

                //do nothing
                return;
            }
        }
        
        if (!PlayerPrefs.HasKey(prefsName))
        {
            SetCoinState(1);
        }
    }

    private void SetCoinState(int state)
    {
        
        PlayerPrefs.SetInt(prefsName, state);
        CheckCoinScene(state);
    }

    private void SpawnFinal()
    {
        GameManager.instance.SpawnFinish();
    }

    private void CheckCoinScene(int state)
    {
        if(state == 0)
        {
            GameManager.instance.SceneCoinAmount += 1;
        }
        
        int coinAmt = GameManager.instance.SceneCoinAmount;
        Debug.Log("Get  Scene Coin" + coinAmt);
        if (coinAmt >= 3)
        {
            SpawnFinal();
        }
    }
}

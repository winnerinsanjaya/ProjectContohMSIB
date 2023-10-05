using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]
    private Text coinText;

    private int coinAmount;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }


        CheckCoin();
    }

    public void AddCoin(int amount)
    {
        coinAmount += amount;
        SaveCoin(coinAmount);
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Jumlah Coin : " + coinAmount; ;
    }

    private void SaveCoin(int amount)
    {
        //save the money to player prefs
        PlayerPrefs.SetInt("Money", amount);
    }

    private void GetCoin()
    {

        //get the "Money" value on playerprefs.
        int amount = PlayerPrefs.GetInt("Money");
        coinAmount = amount;

        UpdateCoinText();
    }

    private void CheckCoin()
    {

        //to check the playerprefs it has "Money" key or not.
        if (PlayerPrefs.HasKey("Money"))
        {
            //get coin
            GetCoin();
        }
        else
        {
            UpdateCoinText();
        }
    }
}

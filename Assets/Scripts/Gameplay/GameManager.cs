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

        UpdateCoinText();
    }

    public void AddCoin(int amount)
    {
        coinAmount += amount;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Jumlah Coin : " + coinAmount; ;
    }
}

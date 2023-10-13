using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]
    private TMP_Text coinText;

    private int coinAmount;

    [SerializeField]
    private GameObject finishObj;

    [SerializeField]
    private Transform finishPos;


    /*
    [SerializeField]
    private GameObject health1;
    [SerializeField]
    private GameObject health2;
    [SerializeField]
    private GameObject health3;
    */

   // [SerializeField]
    public List<GameObject> healthObj;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        AudioPlayer.instance.PlayBGM(1);
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

    public void SetHealthObj(int health)
    {
        switch (health)
        {
            case 3:
                print("Health = " +health);
                healthObj[0].SetActive(true);
                healthObj[1].SetActive(true);
                healthObj[2].SetActive(true);
                break;
            case 2:
                print("Health = " + health);
                healthObj[0].SetActive(true);
                healthObj[1].SetActive(true);
                healthObj[2].SetActive(false);
                break;
            case 1:
                print("Health = " + health);
                healthObj[0].SetActive(true);
                healthObj[1].SetActive(false);
                healthObj[2].SetActive(false);
                break;
            case 0:
                print("Player Die");
                print("Health = " + health);
                healthObj[0].SetActive(false);
                healthObj[1].SetActive(false);
                healthObj[2].SetActive(false);
                break;
            default:
                print("Incorrect health level.");
                break;
        }
    }

    public void SpawnFinish() {

        Instantiate(finishObj, finishPos.position, Quaternion.identity, finishPos);
    }
}

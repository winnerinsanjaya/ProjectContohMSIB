using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    public GameObject collectiblesCanvas;

    private bool pickable;


    private void Start()
    {
        CheckFinishID();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collectiblesCanvas.SetActive(true);
            pickable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collectiblesCanvas.SetActive(false);
            pickable = false;
        }
    }

    private void Update()
    {
        if (pickable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Item Picked");
                SetFinish(0);
                SetPlayerPrefData();
                Destroy(this.gameObject);
            }
        }
    }

    private void SetFinish(int state)
    {
        string scenename = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(scenename + "finish", state);


    }

    private void CheckFinishID()
    {
        string scenename = SceneManager.GetActiveScene().name;

        if (PlayerPrefs.HasKey(scenename + "finish"))
        {
            int coinState = PlayerPrefs.GetInt(scenename + "finish");

            if (coinState == 0)
            {
                Destroy(this.gameObject);
                return;
            }
            if (coinState == 1)
            {
                //do nothing
                return;
            }
        }

        if (!PlayerPrefs.HasKey(scenename + "finish"))
        {
            SetFinish(1);
        }
    }


    private void SetPlayerPrefData()
    {
        if (PlayerPrefs.HasKey("finish"))
        {
            int amt = PlayerPrefs.GetInt("finish");

            int total = amt + 1;
            PlayerPrefs.SetInt("finish", total);
            CheckGameEnd();
            return;
        }

        if (!PlayerPrefs.HasKey("finish"))
        {
            PlayerPrefs.SetInt("finish", 1);
            return;
        }
    }


    private void CheckGameEnd()
    {
        int amt = PlayerPrefs.GetInt("finish");
        if(amt >= 3)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}

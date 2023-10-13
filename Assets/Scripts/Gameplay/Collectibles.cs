using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectibles : MonoBehaviour
{
    public GameObject collectiblesCanvas;

    private bool pickable;

    private string scenename;

    private string prefsName;


    public int itemID;


    public void ItemSet()
    {
        scenename = SceneManager.GetActiveScene().name;

        prefsName = scenename + itemID;
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
                //SetFinish(0);
                SetPlayerPrefData();
                Destroy(this.gameObject);
            }
        }
    }

    private void SetFinish(int state)
    {
        PlayerPrefs.SetInt(prefsName, state);
        CheckFinishScene();
    }

    private void CheckFinishID()
    {
        if (PlayerPrefs.HasKey(prefsName))
        {
            int itemState = PlayerPrefs.GetInt(prefsName);

            if (itemState == 0)
            {
                CheckFinishScene();
                Destroy(this.gameObject);
                return;
            }
            if (itemState == 1)
            {
                //do nothing
                return;
            }
        }

        if (!PlayerPrefs.HasKey(prefsName))
        {
            SetFinish(1);
        }
    }


    private void SetPlayerPrefData()
    {
        SetFinish(0);
    }


    private void CheckFinishScene()
    {
        int itemState = PlayerPrefs.GetInt(prefsName);
        if (itemState == 0)
        {
            GameManager.instance.CheckWinCondition();
        }
    }
}

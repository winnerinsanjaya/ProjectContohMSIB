using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   // public GameManager gameManager;


    private void Start()
    {
       // gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Coin Diambil");
            //gameManager.AddCoin(1);


            //instance
            GameManager.instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SmartPlatform : MonoBehaviour
{
    private PlayerMovement player;
    private TilemapCollider2D tileCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        tileCollider2D = GetComponent<TilemapCollider2D>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
        CheckPlayerPosition();
        GoDown();

    }

    private void GoDown()
    {

        if(Input.GetAxis("Vertical") < 0)
        {
                DisableCollider();
           
        }
    }

    private void CheckPlayerPosition()
    {
        if(transform.position.y > player.transform.position.y)//check if platform above the player
        {
            DisableCollider();
        }

        if(transform.position.y < player.transform.position.y)
        {
            EnableCollider();

        }
    }

    private void DisableCollider()
    {
        tileCollider2D.enabled = false;
    }

    private void EnableCollider()
    {
        tileCollider2D.enabled = true;
    }
}

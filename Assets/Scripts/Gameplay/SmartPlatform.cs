using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPlatform : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
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
        boxCollider2D.enabled = false;
    }

    private void EnableCollider()
    {
        boxCollider2D.enabled = true;
    }
}

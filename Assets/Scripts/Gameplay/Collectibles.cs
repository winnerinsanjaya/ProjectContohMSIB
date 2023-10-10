using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject collectiblesCanvas;

    private bool pickable;
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
                Destroy(this.gameObject);
            }
        }
    }

}

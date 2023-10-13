using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float direction;
    private SpriteRenderer spriteRenderer;


    [SerializeField]
    private float speed = 5f;

    private Animator animator;

    [SerializeField]
    private bool facingLeft;


    [SerializeField]
    private float countDown;
    private float oRcountDown;


    private bool isChanging;
    private void Start()
    {
        countDown = 5f;
        oRcountDown = countDown;
        direction = -1;
        facingLeft = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();

        countDown -= Time.deltaTime;

        if (isChanging)
        {
            direction = 0;
            
        }
        if(countDown <= 0 && isChanging)
        {

            countDown = oRcountDown;

            isChanging = false;

            CountdownDone();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Got Hit");
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.SetHealth(-1);
        }
    }

    public void ChangeDir()
    {

        isChanging = true;
        //StartCoroutine(ChangeDirectionCouroutine());
    }
    private void ChangeDirection()
    {

       


        direction *= -1;
        if(direction == -1)
        {
            //spriteRenderer.flipX = false;
            facingLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
            
            return;
        }

        if (direction == 1)
        {
            facingLeft = false;
            //spriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
            
            return;
        }
    }

    private void Move()
    {
        Vector2 dir = new Vector2(direction, 0);

       
        transform.Translate(dir * Time.deltaTime * speed);

        if(direction != 0)
        {
            animator.SetBool("isRun", true);
        }
        
        if(direction == 0)
        {
            animator.SetBool("isRun", false);
        }
    }


    IEnumerator ChangeDirectionCouroutine()
    {
        //Print the time of when the function is first called.
        direction = 0;



        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
       
    }

    private void CountdownDone()
    {
        if (facingLeft)
        {
            direction = -1;
        }

        if (!facingLeft)
        {
            direction = 1;
        }

        //After we have waited 5 seconds print the time again.
        ChangeDirection();
    }


     
}

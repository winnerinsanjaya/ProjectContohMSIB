using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float JumpPower;

    [SerializeField]
    private int totalJump;

    Rigidbody2D rb;

    public bool isGrounded;

    private int airCount;

    private Animator animator;

    private bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Jump();
    }


    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(x, 0);

        if(x != 0 && !isJump)
        {
            SetAnimParam(true, false);
        }

        if (x == 0 && !isJump)
        {
            SetAnimParam(false, false);
            MoveBackground.instance.Move(0, false);
        }
        transform.Translate(direction * Time.deltaTime * speed);

        

        if (x < 0)
        {
            Facing(false);
            MoveBackground.instance.Move(-1, true);        }

        if (x > 0)
        {
            Facing(true);
            MoveBackground.instance.Move(1, true);
        }
    }

    private void Jump()
    {
        //single jump
        /*
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * JumpPower;
        }*/


        //double jump
        if (Input.GetKeyDown(KeyCode.Space) && airCount < totalJump)
        {
            if (isJump)
            {
                SetAnimParam(false, true);
            }
            
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * JumpPower;
            airCount += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            airCount = 0;
            isGrounded = true;
            Debug.Log("isGrounded");
            isJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("isNotGrounded");
            isJump = true;
        }
    }

    private void Facing(bool isFacingRight)
    {
        if(isFacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        if(!isFacingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
    }


    private void SetAnimParam(bool isRunning, bool isJumping)
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}

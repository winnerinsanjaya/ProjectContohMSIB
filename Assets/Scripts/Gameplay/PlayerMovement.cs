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

    public int airCount;

    private Animator animator;

    public bool isJump;

    public static PlayerMovement instance;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        if(x != 0 && isGrounded)
        {
            SetAnimParam(true, false);
        }

        if (x == 0 && isGrounded)
        {
            SetAnimParam(false, false);
          //  MoveBackground.instance.Move(0, false);
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
            SetAnimParam(false, true);
            
            Vector2 direction = new Vector2(0, 1);
            rb.velocity = direction * JumpPower;
            airCount += 1;
        }
    }

    private void Facing(bool isFacingRight)
    {
        if(isFacingRight)
        {
           // transform.localScale = new Vector3(1, 1, 1);


            //flipX sprite
            spriteRenderer.flipX = false;
            return;
        }
        if(!isFacingRight)
        {
            //transform.localScale = new Vector3(-1, 1, 1);

            //flipX sprite
            spriteRenderer.flipX = true;
            return;
        }
    }


    private void SetAnimParam(bool isRunning, bool isJumping)
    {
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public bool facingRight = false;
    public LayerMask whatIsGround;

    public bool isGrounded = false;
    public bool isFalling = false;
    public bool isJumping = false;

    public float jumpForceX = 2f;
    public float jumpForceY = 4f;

    public float lastYPos = 0;

    public enum Animations
    {
       Idle = 0,
       Jumping = 1,
       Falling = 2
    };
    public Animations currentAnim;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    public float idleTime = 2f;
    public float currentIdleTime = 0;
    public bool isIdle = true;

    public int enemyHealth = 60;


    void Start()
    {
        ChangingAnimation(Animations.Idle);
       
        lastYPos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Only gets called if we are idle
        if (isIdle)
        {
            // add real world time to currentIdleTime
            currentIdleTime += Time.deltaTime;
            // if 2 seconds have passed
            if (currentIdleTime >= idleTime)
            {
                // tell our frog to jump, and change the direction it's facing
                currentIdleTime = 0;
                facingRight = !facingRight;
                spriteRenderer.flipX = facingRight;
                Jump();
            }
        }
        // determines if our is grounded
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), whatIsGround);

        //We have just fallen onto the ground, set idle to true
        if(isGrounded && !isJumping)
        {
            isFalling = false;
            isJumping = false;
            isIdle = true;
            ChangingAnimation(Animations.Idle);
        }
        //we are going up and are not grounded, set isJumping to true
        else if(transform.position.y > lastYPos && !isGrounded && !isIdle)
        {
            isJumping = true;
            isFalling = false;
            ChangingAnimation(Animations.Jumping);
        }
        // we are going down and are not grounded, set isFalling to true
        else if(transform.position.y < lastYPos && !isGrounded && !isIdle)
        {
            isJumping = false;
            isFalling = true;
            ChangingAnimation(Animations.Falling);
        }

        lastYPos = transform.position.y;
    }

    void Jump()
    {
        isJumping = true;
        isIdle = false;
        int direction = 0;
        if (facingRight == true) 
        {
            direction = 1;
        }
        else 
        {
            direction = -1;
        }
        rb.velocity = new Vector2(jumpForceX * direction, jumpForceY);
        //Debug.Log("Jump");
    }

    void ChangingAnimation(Animations newAnim)
    {
        // Only change animation if we aren't already using it
        if (currentAnim != newAnim)
        {
            //Update current animation
            currentAnim = newAnim;
            //Change state variable in our animator 
            anim.SetInteger("state", (int)currentAnim);
        }
    }
}

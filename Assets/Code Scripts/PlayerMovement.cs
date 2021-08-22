using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public int playerHealth = 100;
    public int currentHealth;
    public Health_Bar healthBar;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerHealth -= 10;
            currentHealth = playerHealth;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }

        }

        else if (other.gameObject.tag == "Enemy2")
        {
            playerHealth -= 20;
            currentHealth = playerHealth;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        //boss Dammage
        else if (other.gameObject.CompareTag("Boss"))
        {
            playerHealth -= 30;
            currentHealth = playerHealth;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
        healthBar.SetMaxHealth(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // If the jump button is pressed then the player will jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        currentHealth = playerHealth;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        //move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        // will reset the jump signal so that the player will not jump infinitely
        jump = false;
    }
}

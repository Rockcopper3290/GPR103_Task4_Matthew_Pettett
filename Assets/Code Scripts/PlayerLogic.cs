/// Matthew Pettett
/// GPR 103 - Norman
/// Assessment #2
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class PlayerLogic : MonoBehaviour
{

    public bool playerAlive = true; //Is the player alive (health greater than 0)
    public bool isGameRunning = false; //Is the game running

    public int playerLivesLeft = 3;
    public float playerHealth = 100f; //The players current health
    public float movementSpeed = 10f; //The players current speed

    public int[] numberStorage = new int[3];


    // Start is called before the first frame update
    void Start()
    {
        // Checks to see if the game starts with "isGameRunning == false"
        // if it is false then it sets it to "True"
        if (isGameRunning == false)
        {
            isGameRunning = true;
            print("Welcome to the start of the game.");
        }
    }

    // Update is called once per frame
    void Update()
    {
      // Is player alive?
        // This checks to see if the player is alive.
        // If they are it will allow for the game functions/game "proper", to be played
        if (playerAlive == true)
        {
          // Movement
            //Will move the player up when the 'W' key is pressed
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Time.deltaTime * movementSpeed);
            }

            //Will move the player down when the 'S' key is pressed
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Time.deltaTime * movementSpeed);
            }

            //Will move the player down when the 'A' key is pressed
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
            }

            //Will move the player down when the 'D' key is pressed
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
            }
            //==================================================================================================



            if (Input.GetKeyDown(KeyCode.Space))
            {
               
            }

        }

      // If the player is found to be dead then this will end the game.
        else if (playerAlive == false)
        {
            isGameRunning = false;
        }


    }
}

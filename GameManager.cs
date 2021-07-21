/// Matthew
/// GPR 103 - Norman
/// Assessment #2
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Players Top 3 Highscores
    public int[] highscore = new int[3];
    
    //Gamestate: What section of the game is the player in.
    //e.g. Main menu, playable section (Game) or end screen.
    public string[] gameState = new string[3];

    //To be used to hold a prefab of the player
    public GameObject myPlayerPrefab;


    void Start()
    {
        //Gamestage allocation
        gameState[0] = "MainMenu";
        gameState[1] = "Game";
        gameState[2] = "EndScreen";

        //Highscore allocation
        highscore[0] = 50;
        highscore[1] = 100;
        highscore[2] = highscore[2] + highscore[1];
    }

    void Update()
    {
     
    }

}

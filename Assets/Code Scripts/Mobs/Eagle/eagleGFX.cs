using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class eagleGFX : MonoBehaviour
{
    public AIPath aiPath;
    public int eagleHealth = 20;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f) // based on the speed it will determine if it's flips to the right or left
        {
            transform.localScale = new Vector3(-3f, 3f, 1f);
        } 
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
    }
}

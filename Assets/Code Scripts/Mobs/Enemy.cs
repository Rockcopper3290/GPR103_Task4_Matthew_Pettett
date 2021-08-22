using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;
    public void TakeDammage(int dammage)
    {
        enemyHealth -= dammage;
        if (enemyHealth <= 0)
        {
            Die();
        }
        else if (gameObject.CompareTag("Boss"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

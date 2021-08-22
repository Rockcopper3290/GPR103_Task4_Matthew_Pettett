using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

	public int health = 500;


	public void TakeDammage(int dammage)
	{
			health -= dammage;
		if (health <= 0)
		{
			Die();
		}
	

		if (health <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			Die();
		}
    }

	void Die()
	{
		Destroy(gameObject);

	}
}

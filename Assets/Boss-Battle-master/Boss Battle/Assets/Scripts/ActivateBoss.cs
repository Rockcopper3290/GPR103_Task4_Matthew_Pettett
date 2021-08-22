using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss : MonoBehaviour
{

    public GameObject Boss;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Boss.gameObject.SetActive(true);
        }
    }
}

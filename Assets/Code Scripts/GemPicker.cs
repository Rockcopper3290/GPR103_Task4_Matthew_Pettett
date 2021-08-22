using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemPicker : MonoBehaviour
{
    private float gem = 0f;

    public TextMeshProUGUI textGems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gem"))
        {
            gem++;

            textGems.text = gem.ToString();
            Destroy(other.gameObject);
        }
    }
}

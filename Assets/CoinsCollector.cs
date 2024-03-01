using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    
    public int coins = 0;

    [SerializeField] public Text coinsText;

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
          
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
        }
    }
}


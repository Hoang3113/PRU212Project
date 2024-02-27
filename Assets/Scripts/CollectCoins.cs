using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{

     
    public int coins;

    public Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            coins += 100;
            coinsText.text = "Coins: " + coins;
        }
    }
    public void CoinsUpdate(int amount)
    {
        coins = amount;
        coinsText.text = "Coins: " + coins;
    }
}

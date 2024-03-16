using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{

    public Text coinsText;
    public  int coins = 0;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        UpdateCoins();
        //giu khi chuyen scense
        DontDestroyOnLoad(gameObject); 
    }

    private void UpdateCoins()
    {
        coinsText.text = coins.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            coins++;
            UpdateCoins();
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }
    public void CoinsUpdate(int amount = 0)
    {
        coins = amount;

    }
    // Lấy số coins để sử dụng khi game tắt
    public int GetCoins()
    {
        return coins;
    }
}


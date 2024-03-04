using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    public Text coinsText;
    public int coins = 0;
    

 
    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
           
        }
        UpdateCoinsText();
         
    }

    private void UpdateCoinsText()
    {
        coinsText.text = coins.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            coins++;
            UpdateCoinsText();
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }

    // Lấy số coins để sử dụng khi game tắt
    public  int GetCoins()
    {
        return coins=0;
    }
    public void CoinsUpdate(int amount = 0)
    {
        coins = amount;

    }
}

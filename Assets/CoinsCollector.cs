using UnityEngine;
using UnityEngine.UI;

public class CoinsCollector : MonoBehaviour
{
    public int coins = 0;
    public Text coinsText;

    private void Start()
    {
       
        coins = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.text = "Coins: " + coins.ToString();
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
        // Lưu số coin vào PlayerPrefs trước khi chuyển scene hoặc kết thúc game
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save(); 
    }
}

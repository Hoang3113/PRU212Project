 using UnityEngine;
using UnityEngine.UI;

/*public class CoinsCollector : MonoBehaviour
{
    public Text coinsText;
    public int coins = 0;
    

 
    private void Start()
    {
        
    
        UpdateCoinsText();
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
           
        }
        UpdateCoinsText();
        
        coins = 0;
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
        coins = 0;
    }

   
   
    public void CoinsUpdate(int amount = 0)
    {
        coinsText.text = coins.ToString();
        coins = amount;


    }
}*/
public class CoinsCollector : MonoBehaviour
{
    public Text coinsText;

    private void Start()
    {
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        coinsText.text = GameManager.instance.coins.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.coins++;
            UpdateCoinsText();
        }
    }
    public void CoinsUpdate(int amount = 0)
    {

        GameManager.instance.coins = amount;
        coinsText.text = GameManager.instance.coins.ToString();

    }
}
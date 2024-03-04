using UnityEngine;
using UnityEngine.UI;

public class Key_Collector : MonoBehaviour
{
    public int Key = 0;
    public Text KeyText;

    private void Start()
    {

        Key = PlayerPrefs.GetInt("Key", 0);
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        KeyText.text = "Key: " + Key.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            
            Key++;
            UpdateCoinsText();
        }
    }

  
}

using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Key_Collect : MonoBehaviour
{
    public Text KeyText;
    public int key = 0;

    private void Start()
    {
        key = 0; 

        UpdateKeyText();

    }

    private void UpdateKeyText()
    {
        KeyText.text = key.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Chest"))
        {
            string chestName = collision.gameObject.name; // Lấy tên của chest
            string chestKey = chestName + "isOpen";
            if (!PlayerPrefs.HasKey(chestKey))
            {
                key=1;
                UpdateKeyText();
            }
        }
    }

   

  
 
}
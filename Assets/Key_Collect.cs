using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Key_Collect : MonoBehaviour
{
    public Text KeyText;
    private int key;

    private bool chestCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chest") && !chestCollected)
        {
            key++;
            chestCollected = true;
            UpdateKeyText();
          
          
        }
    }

    private void UpdateKeyText()
    {
        if (KeyText != null)
        {
            KeyText.text = key.ToString();
        }
    }
}

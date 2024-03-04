using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ChestOpener : MonoBehaviour {
    public Sprite openChestSprite; // Hình ảnh đại diện cho hòm đã mở
    private SpriteRenderer spriteRenderer; // Đối tượng SpriteRenderer của hòm
   
    private bool isOpen = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenTheChest();
        }
    }

    private void OpenTheChest()
    {
      
       

        spriteRenderer.sprite = openChestSprite;
        isOpen = true;
    }
       }

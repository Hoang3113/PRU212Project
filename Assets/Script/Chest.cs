using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class ChestOpener : MonoBehaviour {
    public Sprite openChestSprite;
    public GameObject keyPrefab; // Prefab của chìa khóa
    public Vector3 keySpawnOffset = new Vector3(0f, 0.5f, 0f); // Offset để di chuyển chìa khóa lên trên đầu hòm
    private SpriteRenderer spriteRenderer;
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

        
        SpawnKey();
    }

    private void SpawnKey()
    {
        if (keyPrefab != null)
        {
         
            GameObject keyInstance = Instantiate(keyPrefab, transform.position + keySpawnOffset, Quaternion.identity);
        
            keyInstance.tag = "Key";
        }
        else
        {
            Debug.LogWarning("Prefab của chìa khóa chưa được đặt!");
        }
    }
}

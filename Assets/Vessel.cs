using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    public Sprite openVesselSprite;
    public GameObject HealPrefab; 
    public Vector3 healSpawnOffset = new Vector3(0f, 0.7f, 0f); 
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
            OpenTheVessel();
        }
    }

    private void OpenTheVessel()
    {
        spriteRenderer.sprite = openVesselSprite;
        isOpen = true;


        SpawnItem();
    }

    private void SpawnItem()
    {
        if (HealPrefab != null)
        {

            GameObject keyInstance = Instantiate(HealPrefab, transform.position + healSpawnOffset, Quaternion.identity);

            keyInstance.tag = "Heal";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    public Sprite openVesselSprite;
    public Vector3 healSpawnOffset = new Vector3(0f, 0.7f, 0f);
    public GameObject HealPrefab;
    public float healDuration = 1f;
    private SpriteRenderer spriteRenderer;
    public Health health;
    private bool isOpen = false;
   

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
    //    {
    //        OpenTheVessel();
    //    }
    //}

    public void OpenTheVessel()
    {
        if (!isOpen)
        {
            spriteRenderer.sprite = openVesselSprite;
              isOpen = true;
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        if (HealPrefab != null)
        {
            GameObject healInstance = Instantiate(HealPrefab, transform.position + healSpawnOffset, Quaternion.identity);
            Debug.Log("Spawned item");
            health.AddHealth(20);

         
            Destroy(healInstance, healDuration);
        }
    }
}

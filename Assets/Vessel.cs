﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    public Sprite openVesselSprite;
    public GameObject HealPrefab;
    public Vector3 healSpawnOffset = new Vector3(0f, 0.7f, 0f);
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
        //   isOpen = true;
        if (!isOpen)
        {
            SpawnItem();
            spriteRenderer.sprite = openVesselSprite;
            isOpen = true;
        }
    }

    private void SpawnItem()
    {
        if (HealPrefab != null)
        {

            GameObject keyInstance = Instantiate(HealPrefab, transform.position + healSpawnOffset, Quaternion.identity);

            Debug.Log("SpawnItem");

            health.AddHealth(20);
        }
    }
}

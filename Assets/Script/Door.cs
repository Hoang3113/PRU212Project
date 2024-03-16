using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite openDoorSprite;

    public SpriteRenderer spriteRenderer ;
    private bool isOpen = false;
   private  void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenTheDoor();
        }
    }
    private void OpenTheDoor()
    {

        spriteRenderer.sprite = openDoorSprite;
        isOpen = true;
    }
}

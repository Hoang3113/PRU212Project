using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;


public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite openDoorSprite;
    public Key_Collect keyCollector;
    public SpriteRenderer spriteRenderer ;
    private bool isOpen = false;
   private  void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
  /*  private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            if (keyCollector.key != null)
            {
                OpenTheDoor();
            }
        }
    }*/
    public void OpenTheDoor()
    {

        spriteRenderer.sprite = openDoorSprite;
        isOpen = true;
    }
}

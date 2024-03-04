using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Sence_Controller.instance.NextLevel();
        }
    }
}

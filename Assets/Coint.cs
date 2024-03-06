using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour
{
   [SerializeField] public int value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player" ))
        {
            Destroy(gameObject);
           // CoinsCollector.intance.UpdateCoints(value);
        }
        
    }
}

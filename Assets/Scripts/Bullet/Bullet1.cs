using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float speed = -10f;
    public int damage =5;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health player = hitInfo.GetComponent<Health>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}

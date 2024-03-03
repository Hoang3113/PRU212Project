using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentpoint;
    private int health;
    public float speed;
    private float dazedTime;
    public float startDazedTime;
    
    public GameObject bloodEffect;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentpoint = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //dazez enemey
        if(dazedTime <= 0)
        {
            speed = -2;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        //move
        Vector2 point = currentpoint.position - transform.position;
        if (currentpoint == pointA.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointA.transform)
        {
            flip();
            currentpoint = pointB.transform;
        }
        if (Vector2.Distance(transform.position, currentpoint.position) < 0.5f && currentpoint == pointB.transform)
        {
            flip();
            currentpoint = pointA.transform;
        }

        //die if health = 0
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

    public void TakeDamage(int damage) 
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage TAKEN!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Heath : MonoBehaviour
{
    public int health;

    public GameObject deathEffect;

    public bool isInvulnerable = false;
    public Animator animator;

    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        Debug.Log("TAK DAMG");
        if (isInvulnerable)
            return;

        health -= damage;
        animator.SetTrigger("TakeHit");

        //if (health <= 200)
        //{
        //    GetComponent<Animator>().SetBool("IsEnraged", true);
        //}

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        animator.SetTrigger("Death");
        //Destroy(gameObject);
    }
    void DestrouObject()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //animator.SetTrigger("Death");
        Destroy(gameObject);
    }
}

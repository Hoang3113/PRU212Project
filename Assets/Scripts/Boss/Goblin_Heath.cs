using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Heath : MonoBehaviour
{
    public int health;
    public bool isInvulnerable = false;

    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

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
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

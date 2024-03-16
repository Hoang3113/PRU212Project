using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] public float startingHealth;

    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public HealthBarLine healthBarLine;
    public float defense = 0;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        healthBarLine.SetMathHealth(startingHealth); 
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - (_damage - _damage * defense), 0, startingHealth);
        healthBarLine.SetHealth(currentHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;    
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        healthBarLine.SetHealth(currentHealth);
        Debug.Log("ADD HEALTH");
    }

    public void Respawn()
    {
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        dead = false;
        GetComponent<PlayerMovement>().enabled = true;
        anim.Play("None");
    }
    public void UpdateHealth(float value)
    {
        startingHealth = startingHealth + value;
        currentHealth = currentHealth + value*2;
        healthBarLine.SetHealth(currentHealth);
        healthBarLine.SetMathHealth(startingHealth);
    }
    public void UpdateDefense(float value)
    {
        defense = defense + value;
    }
}

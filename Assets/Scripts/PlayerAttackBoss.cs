using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBoss : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask whatIsEnemies;
    [SerializeField] private LayerMask vessel;
    [SerializeField] private float attackRange;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            //then you can attack
            if(Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Goblin_Heath>().TakeDamage(damage);
                }
                Collider2D[] vesselToBreak = Physics2D.OverlapCircleAll(attackPos.position, attackRange, vessel);
                for (int i = 0; i < vesselToBreak.Length; i++)
                {
                    vesselToBreak[i].GetComponent<Vessel>().OpenTheVessel();
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

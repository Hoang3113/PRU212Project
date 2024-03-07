using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Attack : MonoBehaviour
{
    public int attackDamage;
    public int enragedAttackDamage;

    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask attackMask;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int spell_conddition;
    public Animator animator;

    private int mana = 0;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            //colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void Update()
    {
        mana++;
        if (mana == spell_conddition)
        {
            animator.SetTrigger("Spell");
            Shoot();
            mana = 0;
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool canDamage = true;
    private float damageCooldown = 2f; // Thời gian cooldown giữa mỗi lần đụng

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && canDamage)
        {
            collider.GetComponent<Health>().TakeDamage(damage);
            canDamage = false;
            StartCoroutine(ResetDamageCooldown());
        }
    }

    private IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}

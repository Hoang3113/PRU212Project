using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uIManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uIManager = FindObjectOfType<UIManager>();
        if (uIManager != null)
            uIManager.SetPlayerRespawn(this);
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint != null)
        {
            uIManager.GameOver();
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}

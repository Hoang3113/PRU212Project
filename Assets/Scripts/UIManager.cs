using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    private PlayerRespawn playerRespawn;


    public void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void SetPlayerRespawn(PlayerRespawn respawn)
    {
        playerRespawn = respawn;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        if (playerRespawn != null)
            playerRespawn.Respawn();
        gameOverScreen.SetActive(false);
    }
}
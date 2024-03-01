using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float delaySecond = 1;
    public string nameScene = "Level_2";
    public GameObject fadeOutPanel;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.SaveData();
            StartCoroutine(LoadAfterDelay());
        }
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);
        fadeOutPanel.SetActive(true); // hiển thị panel fade out
        yield return new WaitForSeconds(1); // thời gian fade out

        gameManager.LoadNextLevel();
    }
}

using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite openDoorSprite;
    public float delaySecond = 0.5f;
    public string nameScene = "Level_2";
    public Key_Collect keyCollector;
    public GameManager gameManager; private bool isOpen = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        keyCollector = GameObject.FindObjectOfType<Key_Collect>(); // Tìm đối tượng Key_Collect trong scene
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (keyCollector.key >= 1)
            {

                OpenTheDoor();
                gameManager.SaveData();
                
                StartCoroutine(LoadAfterDelay());
            }
            else
            {
                Debug.Log("You need at least 2 keys to unlock the next level!");
            }
        }
    }
    public void OpenTheDoor()
    {

        spriteRenderer.sprite = openDoorSprite;
        isOpen = true;
    }
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);

        yield return new WaitForSeconds(1);

        gameManager.LoadNextLevel();
    }
}

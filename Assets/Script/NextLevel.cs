using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float delaySecond = 1;
    public string nameScene = "Level_2";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int collectedKeys = PlayerPrefs.GetInt("SavedKey", 0); 
            if (collectedKeys >= 1) 
            {
                
                StartCoroutine(LoadAfterDelay());
            }
            else
            {
                Debug.Log("You need at least 2 keys to unlock the next level!");
            }
        }
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);
       
        yield return new WaitForSeconds(1); 

        SceneManager.LoadScene(nameScene);
    }
}

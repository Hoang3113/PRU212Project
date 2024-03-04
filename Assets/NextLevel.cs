using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float delaySecond = 1;
    public string nameScene = "Level_2";
    [SerializeField] Animator trasitionAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadAfterDelay());
        }
    }

    IEnumerator LoadAfterDelay()
    {
        trasitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nameScene);
        trasitionAnim.SetTrigger("Start");
    }
}

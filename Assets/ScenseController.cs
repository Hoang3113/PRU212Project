using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenseController : MonoBehaviour
{
    public static ScenseController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName); Destroy(gameObject);
    }
}

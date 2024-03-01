using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize(UnityEngine.SceneManagement.Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
        
    }

    public void LoadLevel()
    {
        if(saveSystem != null && saveSystem.LoadedData != null)
        {
            Debug.Log("Load level work");
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }
    
    public void LoadNextLevel()
    {
        Debug.Log("Load next level work");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if(player != null)
        {            
            Debug.Log("load save data");
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1);
        }        
    }
}

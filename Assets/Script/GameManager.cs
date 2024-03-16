using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;
    public static GameManager instance;

    public int coins = 0;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Đảm bảo rằng GameManager không bị hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void CoinsUpdate(int amount = 0)
    {
        CoinsCollector collectCoinsScript = FindObjectOfType<CoinsCollector>();
        GameManager.instance.coins = amount;
        collectCoinsScript.coinsText.text= GameManager.instance.coins.ToString();

    }
    private void Initialize(UnityEngine.SceneManagement.Scene scene, LoadSceneMode sceneMode)
    {
        Debug.Log("Loaded GM");
    }

    public void LoadLevel()
    {
        if(saveSystem != null && saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }
    
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if(player != null)
        {
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

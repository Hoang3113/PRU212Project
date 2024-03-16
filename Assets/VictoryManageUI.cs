using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManageUI : MonoBehaviour
{
    [SerializeField] private GameObject victoryScreenObject;

    public void Awake(){
        victoryScreenObject.SetActive(false);
    }

    public void GameVictory(){
        victoryScreenObject.SetActive(true);
    }

    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

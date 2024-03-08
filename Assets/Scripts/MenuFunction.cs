
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunction : MonoBehaviour
{
    public string nameScene = "Level1";
  
    public void NewGame()
    {

        PlayerPrefs.SetInt("IsGameSaved", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nameScene);
    }
    
    public void Continue()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}

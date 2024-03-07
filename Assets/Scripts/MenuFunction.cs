using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunction : MonoBehaviour
{
    public string nameScene = "Level1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
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

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public int coins;
    public GameObject PauseMenuUI;
    public Text HealthText;
    public Text AttackText;
    public Text DefenseText;
    public Text SpeedText;
    public Text JumpText;
    public float Health;
    public int Attack;
    public float Defense;
 /*   public float Speed;
    public float Jump;*/
    public Text Successful;
    public Text Fail;

    public int PriceHeath = 5;
    public int PriceAttack = 5;
    public int PriceDefense = 10;
   /* public int PriceSpeed = 20;
    public int PriceJump = 20;*/

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                Successful.text = null;
                Fail.text = null;
            }
            GameManager collectCoinsScript = FindObjectOfType<GameManager>();
            Health player_Heath = FindObjectOfType<Health>();
            PlayerAttack playerAttack = FindObjectOfType<PlayerAttack>();   
            if (player_Heath != null) 
            {
                Health = player_Heath.startingHealth;
                Defense = player_Heath.defense;
            }
            if (playerAttack != null)
            {
                Attack = playerAttack.damage;
            }
            if (collectCoinsScript != null)
            {
                coins = collectCoinsScript.coins;
                Debug.Log("Current Coins: " + coins);
            }

            HealthText.text = "Health : " + Health;
            AttackText.text = "Attack : " + Attack;
            DefenseText.text = "Defense : " + Defense;
            /*SpeedText.text = "Speed : " + Speed;
            JumpText.text = "Jump : " + Jump;*/

            PriceHeath = 5;
            PriceAttack = 5;
            PriceDefense = 1;
           /* PriceSpeed = 20;
            PriceJump = 20;*/
        }  
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    { 
        Application.Quit();
    }

    public void IncreaseHealth(int amount)
    {
        GameManager collectCoinsScript = FindObjectOfType<GameManager>();
        Health player_Heath = FindObjectOfType<Health>();
        if (coins >= PriceHeath)
        {
            Health += 20;
            HealthText.text = "Health : " + Health;
            coins = coins - PriceHeath;
            player_Heath.UpdateHealth(20);
            collectCoinsScript.CoinsUpdate(coins);
            Successful.text = "Increasing Successful!";
            Fail.text = null;
            Debug.Log("Current Coins: " + coins);
        }
        else 
        {
            Fail.text = "Not enough coins!";
            Successful.text = null;
        }
    }

    public void IncreaseAttack(int amount)
    {
        GameManager collectCoinsScript = FindObjectOfType<GameManager>();
        PlayerAttack playerAttack = FindObjectOfType<PlayerAttack>();

        if (coins >= PriceAttack)
        {
            Attack += 5;
            AttackText.text = "Attack : " + Attack;
            coins = coins - PriceAttack;
            playerAttack.UpdateDamage(5);
            collectCoinsScript.CoinsUpdate(coins);
            Successful.text = "Increasing Successful!";
            Fail.text = null;
        }
        else
        {
            Fail.text = "Not enough coins!";
            Successful.text = null;
        }
    }
    public void BackToMenu(){
            SceneManager.LoadScene(0);
         
    }
    public void IncreaseDefense()
    {
        CoinsCollector collectCoinsScript = FindObjectOfType<CoinsCollector>();
        Health player_Heath = FindObjectOfType<Health>();
        if (coins >= PriceDefense)
        {
            Defense += 0.05f;
            if (Defense >= 0.95f) 
            {
                Fail.text = "Maximum!";
                Successful.text = null;
            }
            else 
            { 
                DefenseText.text = "Defense : " + Defense;
                coins = coins - PriceDefense;
                collectCoinsScript.CoinsUpdate(coins);
                player_Heath.UpdateDefense(0.05f);
                Successful.text = "Increasing Successful!";
                Fail.text = null;
            }
        }
        else
        {
            Fail.text = "Not enough coins!";
            Successful.text = null;
        }
    }

   /* public void IncreaseSpeed()
    {
        CoinsCollector collectCoinsScript = FindObjectOfType<CoinsCollector>();
        if (coins >= PriceSpeed)
        {
            Speed += 100;
            SpeedText.text = "Speed : " + Speed;
            coins = coins - PriceSpeed;
            collectCoinsScript.CoinsUpdate(coins);
            Successful.text = "Increasing Successful!";
            Fail.text = null;
        }
        else
        {
            Fail.text = "Not enough coins!";
            Successful.text = null;
        }
    }

    public void IncreaseJump()
    {
        CoinsCollector collectCoinsScript = FindObjectOfType<CoinsCollector>();
        if (coins >= PriceJump)
        {
            Jump += 0.1f;
            JumpText.text = "Jump : " + Jump;
            coins = coins - PriceJump;
            collectCoinsScript.CoinsUpdate(coins);
            Successful.text = "Increasing Successful!";
            Fail.text = null;
        }
        else
        {
            Fail.text = "Not enough coins!";
            Successful.text = null;
        }
    }
*/

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

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
    public int Health;
    public int Attack;
    /*public int Defense;
    public float Speed;
    public float Jump;*/
    public Text Successful;
    public Text Fail;

    public int PriceHeath = 10;
    public int PriceAttack = 10;
    /*public int PriceDefense = 30;
    public int PriceSpeed = 50;
    public int PriceJump = 50;*/
    
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
            Player_Heath player_Heath = FindObjectOfType<Player_Heath>();
            if (player_Heath != null) 
            {
                Health = player_Heath.health;
            }
            if (collectCoinsScript != null)
            {
                coins = collectCoinsScript.coins;
                Debug.Log("Current Coins: " + coins);
            }

            HealthText.text = "Health : " + Health;
            AttackText.text = "Attack : " + Attack;
            /*DefenseText.text = "Defense : " + Defense;
            SpeedText.text = "Speed : " + Speed;
            JumpText.text = "Jump : " + Jump;*/

            PriceHeath = 10;
            PriceAttack = 10;
            /*PriceDefense = 30;
            PriceSpeed = 50;
            PriceJump = 50;*/
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
        if (coins >= PriceHeath)
        {
            Health += 100;
            HealthText.text = "Health : " + Health;
            coins = coins - PriceHeath; 
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
        if (coins >= PriceAttack)
        {
            Attack += 100;
            AttackText.text = "Attack : " + Attack;
            coins = coins - PriceAttack;
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

    /*public void IncreaseDefense()
    {
        CoinsCollector collectCoinsScript = FindObjectOfType<CoinsCollector>();
        if (coins >= PriceDefense)
        {
            Defense += 100;
            DefenseText.text = "Defense : " + Defense;
            coins = coins - PriceDefense;
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

    public void IncreaseSpeed()
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
    }*/

   
}

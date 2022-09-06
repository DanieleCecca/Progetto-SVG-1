using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeRemaining = 10;
    [SerializeField]
    private bool timerIsRunning = false;
    [SerializeField]
    private TextMeshProUGUI timeText;

    public CoinCounter coinCounter;
    //public CoinCounterEnemy coinCounterEnemy;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            calculateTimeRemaining();
        }
    }

    //funzione che permette di calcolare il tempo rimanente sottraendo Time.deltaTime che dovrebbe ritornare i secondi che passano ogni frame
    private void calculateTimeRemaining()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            timerIsRunning = false;

            if (IsMaxCoins())
            {
                GameManager.instance.WinGame();
               
            }
            else
            {
                GameManager.instance.LoseGame();
            }
            //lanciare la funzione che chiama la schermata di fine partita che andrà spostata in un game manager
        }
    }

    //fuznione che trasforma il tempo in stringa in modo tale da poter essere visualizzato con l'oggetto UI text
    //vieni inserito + 1 perchè altrimenti partirebbe un secondo indietro
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public bool IsMaxCoins()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        int enemyCoins = findMax(enemies);
        return (coinCounter.numberCoin > enemyCoins);

    }


    public int findMax(GameObject[] enemies)
    {
        GameObject enemy = enemies[0];
        int maxCoins = enemy.GetComponent<CoinCounterEnemy>().numberCoin;
        
        for(int i = 1; i< enemies.Length - 1; i++)
        {
            enemy = enemies[i];
            if (maxCoins < enemy.GetComponent<CoinCounterEnemy>().numberCoin)
            {
                maxCoins = enemy.GetComponent<CoinCounterEnemy>().numberCoin;
            }

        }
        return maxCoins;
    }
}


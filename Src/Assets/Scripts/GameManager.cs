using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject VictoryEndGameUI;
    public GameObject DefeatEndGameUI;
    public float attesa=5f;

    public GameObject[] characterPrefabs;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    public GameObject healthPrefab;
    public GameObject shieldPrefab;
    public GameObject powerPrefab;

 

    public bool endGame = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       //istanzio i vari elementi
       if(SceneManager.GetActiveScene().name== "Arena0")
        {


            LoadCoin();
        }
        else if (SceneManager.GetActiveScene().name == "Arena1")
        {

            LoadCoin();
            LoadPropShield();
        }
        else if (SceneManager.GetActiveScene().name == "Arena2")
        {

            LoadCoin();
            LoadPropShield();
            LoadPropDamage();
        }
        if (SceneManager.GetActiveScene().name == "Arena3")
        {

            LoadCoin();
            LoadPropDamage();
            LoadPropHealth();
            LoadPropShield();
        } 
    }

    public void LoseGame()
    {
        endGame = true;
        //attiva il panel sconfitta oppure quando termina il tempo 
        DefeatEndGameUI.SetActive(true);
        Invoke("CompleteGame", attesa);
        
    }

    
    public void WinGame()
    {
        endGame = true;
        //attiva il canva vittoria
        VictoryEndGameUI.SetActive(true);
        Invoke("CompleteGame", attesa);
    }



    public void LoadCoin()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius; 
        Instantiate(coinPrefab, position, Quaternion.identity);

    }
    public void LoadPropShield()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius; 
        Instantiate(shieldPrefab, position, Quaternion.identity);
    }
    public void LoadPropHealth()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius;
        Instantiate(healthPrefab, position, Quaternion.identity);
    }
    public void LoadPropDamage()
    {
        float planetRadius = 50;//raggio fel pianeta
        Vector3 position = Random.insideUnitSphere * planetRadius;
        Instantiate(powerPrefab, position, Quaternion.identity);
    }

}

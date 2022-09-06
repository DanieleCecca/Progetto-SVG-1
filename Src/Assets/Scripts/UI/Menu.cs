using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

    [SerializeReference]
    GameObject SettingsUI;
    [SerializeReference]
    GameObject canvasTutorial;

    /*La funzione corretta è inserita in LevelSelector
     * public void PlayGame()
     {
         SceneManager.LoadScene("Arena1");
     }
     */

    public void OpenSettings()
    {
        SettingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
    }
   public void OpenShop()
    {
         SceneManager.LoadScene("Shop");

    }
    public void OpenGarage()
    {
        SceneManager.LoadScene("Garage");
    }

    public void OpenHome()
    {
        SceneManager.LoadScene("Home");
        
    }

    public void closeDefeatVictoryPanel(GameObject panel)
    {
        //panel.SetActive(false);
        GameManager.instance.endGame = false;
        GameManager.instance.GetComponent<PauseGameplay>().Resume();
        OpenHome();
    }

    public void closeTutorial()
    {
        canvasTutorial.gameObject.SetActive(false);
        GameManager.instance.GetComponent<PauseGameplay>().Resume();
    }
   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{
    public Swipe swipe;

    private void Start()
    {
    }
    public void PlayFuction() 
    {
        string levelName = "Arena" + swipe.elementSelected;
        SceneManager.LoadScene(levelName);
    }
}

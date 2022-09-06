using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGameplay : MonoBehaviour
{

    [SerializeField]
    public bool isPaused = false;
    //public Canvas canvasTutorial;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Arena0")
            Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.endGame == true)
        {
            Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        
        Time.timeScale = 1f;
        isPaused = false;
        
    }

}

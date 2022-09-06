using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerCount : MonoBehaviour
{
    public int numberPlayers = 0;
    public int playersMax = 0;
    [SerializeField]
    private TextMeshProUGUI playersText;
    GameObject[] players;
    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("player");
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        playersMax = players.Length + enemies.Length;
        numberPlayers = players.Length + enemies.Length;
        Displayplayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void countPlayer()
    {
       
        numberPlayers --;
        Debug.Log(numberPlayers);
        Displayplayer();
    }

    public void Displayplayer()
    {
        playersText.text = numberPlayers.ToString() +"/"+ playersMax.ToString();
    }
}

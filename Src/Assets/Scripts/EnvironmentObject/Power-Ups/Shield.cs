using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour

{
    public GameObject shield;
    public GameObject player;
    
    // Start is called before the first frame update

    public void ActiveShield()
    { 
        shield.SetActive(true);
        if (player.tag == "player")
        {
            player.GetComponent<PlayerHealth>().isShield = true;
        }
        else if(player.tag == "enemy")
        {
            player.GetComponent<EnemyLife>().isShield = true;
        }
    }
    public void DisableShield()
    {
        shield.SetActive(false);
        if (player.tag == "player")
        {
            player.GetComponent<PlayerHealth>().isShield = false;
        }
        else if (player.tag == "enemy")
        {
            player.GetComponent<EnemyLife>().isShield = false;
        }

    }
}

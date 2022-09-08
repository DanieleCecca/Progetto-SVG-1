using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDmg : MonoBehaviour
{
    public GameObject boostDmg;
    public GameObject player;

    // Start is called before the first frame update

    public void ActiveBoost()
    {
        boostDmg.SetActive(true);
       
    }
    public void DisableBoost()
    {
        boostDmg.SetActive(false);
      
    }
}


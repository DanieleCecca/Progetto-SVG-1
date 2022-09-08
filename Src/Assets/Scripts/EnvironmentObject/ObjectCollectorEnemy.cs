using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectorEnemy : MonoBehaviour
{
    [SerializeField]
    private CoinCounterEnemy coinCounterEnemy;
    [SerializeField]
    private Shield shield;
    [SerializeField]
    private EnemyLife enemyLife;
    [SerializeField]
    private EnemyCollisonBullet enemyCollisionbullet;
    [SerializeField]
    private BoostDmg boostDmg;


    //non si può utlizzare questa funzione poichè in quetso caso con la funzione trigger bisogna attivare is trigger
    //che disabilita la gravità e se non ci fosse la gravità le monete andrebbero a fanculo per questo come soluzione basta 
    //basta dimuire la massa dell'oggetto raccolto o aumentare quella della macchina chiaramente andando poi ad aumentare la
    //forza di gravità

    /*private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == "coin")
        {
            coinCounter.addCoin();
            Destroy(colliderInfo.gameObject);
        }
            

        else if (colliderInfo.tag == "powerUp")
        {
            //realizzare una funzione che attivi il powerUp/ come  è stato fatto per coinCounter.Add
            Destroy(colliderInfo.gameObject);
        }
    }
    */

    private void Awake()
    {
       
    }

    //Questa funzione permette al momento della collisione con la moneta o con il powerUp di richiamare nel
    //caso della moneta una funzione che aumenta il numero di monete raccolte,il quale sarà presente nello script 
    //Coin Countere e nel caso del powerUp richiamerà una ipotetica funzione che modifica delle stats,
    //presente anche essa in un altro script.Quando avviene la collisione l'oggetto raccolto viene ditrutto.
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "coin")
        {
            Debug.Log("nemico raccolto moneta");
            coinCounterEnemy.addCoin();
            Destroy(collisionInfo.collider.gameObject);
        }


        else if (collisionInfo.collider.tag == "shield")
        {
            ActiveShield();
            Destroy(collisionInfo.collider.gameObject);
        }
        else if (collisionInfo.collider.tag == "health")
        {
            incrementHealth();
            Destroy(collisionInfo.collider.gameObject);
        }
        else if (collisionInfo.collider.tag == "boostDmg")
        {
            boostBulletDamage();
            Destroy(collisionInfo.collider.gameObject);
        }

    }
    void boostBulletDamage()
    {
        boostDmg.ActiveBoost();
        int newDamage = 33;
        enemyCollisionbullet.boostBulletDamage(newDamage);
        Invoke("DisableBoost", EnemyCollisonBullet.time);


    }

    //bisogna creare per forza questa funzione per usare invoke
    void DisableBoost()
    {
        boostDmg.DisableBoost();
    }


    void incrementHealth()
    {
        int healthPoints = 33;
        enemyLife.incrementHealth(healthPoints);
    }
    void ActiveShield()
    {
        shield.ActiveShield();
       
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDash : MonoBehaviour
{

    public float initialSpeed;
    public GameObject enemy;
    public CoinCounter coinCounter;
    public CoinCounterEnemy coinCounterEnemy;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = enemy.GetComponent<AIEnemy>().getSpeed();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        int dashDamage = 30;

        if (enemy.GetComponent<AIEnemy>().getSpeed() > initialSpeed)
        {
            //caso in cui venga colpito il player 
            if (collision.gameObject.name == "Player 1")//this.GetComponent<GameObject>()
            {

                PlayerHealth playerLife = collision.gameObject.GetComponent<PlayerHealth>();
                //se è attivo lo scudo
                if (collision.gameObject.GetComponent<PlayerHealth>().isShield)
                {
                    Debug.Log("cazzo sbrutto");
                    collision.gameObject.GetComponentInChildren<Shield>().DisableShield();
                   // Destroy(collision.gameObject);
                }
                else if (playerLife != null)
                {
                    playerLife.decreaseHealth(dashDamage);
                }

                coinCounter = collision.gameObject.GetComponent<CoinCounter>();
                if (coinCounter.numberCoin > 0)
                {
                    coinCounter.loseCoinOnDash(coinCounter.numberCoin / 2, collision.gameObject);//cosi perderà sempre la meta delle monete che ha
                }
            }

            
            //caso in cui venga colpito un nemico che non sia il player e se stesso
            else if (collision.gameObject.tag == "enemy" && collision.gameObject!=gameObject)
            {
                EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();
                //se è attivo lo scudo
                if (collision.gameObject.GetComponent<EnemyLife>().isShield)
                {
                    //forse bisogna distruggere anche il bullet

                    Debug.Log(collision.gameObject.name);
                    collision.gameObject.GetComponentInChildren<Shield>().DisableShield();
                    // Destroy(collision.gameObject);
                }
                
                else if (enemyLife != null)
                {
                    enemyLife.decreaseHealth(dashDamage);
                }

                coinCounterEnemy = collision.gameObject.GetComponent<CoinCounterEnemy>();
                if (coinCounter.numberCoin > 0)
                {
                    coinCounterEnemy.loseCoinOnDash(coinCounter.numberCoin / 2, collision.gameObject);//cosi perderà sempre la meta delle monete che ha
                }
            }
            else
            {
                Debug.Log("Non hai colpito il player");
            }

        }
    }
}

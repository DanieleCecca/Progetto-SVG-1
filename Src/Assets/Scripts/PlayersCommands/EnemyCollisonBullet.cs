using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisonBullet : MonoBehaviour
{
    private int bulletDamage = 10;
    int initialbulletDamage;
    public static float time = 5f;
    public GameObject itSelf;//che sarà o il player o l'enemy

    public int getBulletDamage()
    {
        return bulletDamage;
    }
    public void setBulletDamage(int damage)
    {
        bulletDamage = damage;
    }


    void Start()
    {
        initialbulletDamage = bulletDamage;
    }
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.body);
        Debug.Log(collision.gameObject);
        Debug.Log(collision.articulationBody);

        if (collision.gameObject.tag == "player")
        {
            Debug.Log("Hai colpito il player");
            Destroy(gameObject);

            PlayerHealth playerLife = collision.gameObject.GetComponent<PlayerHealth>();
            //se è attivo lo scudo
            if (collision.gameObject.GetComponent<PlayerHealth>().isShield)
            {
                //forse bisogna distruggere anche il bullet
                collision.gameObject.GetComponentInChildren<Shield>().DisableShield();
                Destroy(gameObject);
            }
            else if (playerLife != null)
            {
                Debug.Log("cazzo sbrutto");
                playerLife.decreaseHealth(getBulletDamage());
            }

        }
        
        else if (collision.gameObject.tag == "enemy" && collision.gameObject!= itSelf)
        {
            Debug.Log("Hai colpito il nemico");
            Destroy(gameObject);
            EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();
            if (collision.gameObject.GetComponent<EnemyLife>().isShield)
            {
                //forse bisogna distruggere anche il bullet

                Debug.Log(collision.gameObject.name);
                collision.gameObject.GetComponentInChildren<Shield>().DisableShield();
                // Destroy(collision.gameObject);

                Destroy(gameObject);
            }
            else if (enemyLife != null)
            {
                enemyLife.decreaseHealth(getBulletDamage());
            }
            
        }
        
        else
        {
            Debug.Log("Non hai colpito il player");
        }

    }

    public void boostBulletDamage(int newDamage)
    {
        
        setBulletDamage(newDamage);
        Debug.Log("Danno aumentato: " + newDamage);
        Invoke("ResetBoost", time);
    }

    public void ResetBoost()
    {
        setBulletDamage(initialbulletDamage);
        Debug.Log("Boost damage resettato");
    }
}

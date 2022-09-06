using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour
{
    private int bulletDamage = 10;
    int initialbulletDamage;
    private float time = 5f;
    public GameObject player;//che sarà o il player o l'enemy
    [SerializeField]
    private GameObject boostDmgEffect;


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

        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
            EnemyLife enemyLife = collision.gameObject.GetComponent<EnemyLife>();
            //se è attivo lo scudo
            if (collision.gameObject.GetComponent<EnemyLife>().isShield)
            {

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
            Debug.Log("Non hai colpito il nemico");



    }

    public void boostBulletDamage(int newDamage)
    {
        boostDmgEffect.SetActive(true);
        setBulletDamage(newDamage);
        Debug.Log("Danno aumentato: " + newDamage);
        Invoke("ResetBoost", time);
    }

    public void ResetBoost()
    {
        boostDmgEffect.SetActive(false);
        setBulletDamage(initialbulletDamage);
        Debug.Log("Boost damage resettato");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isShield;

    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private GameObject healingEffect;

    void Start()
    {
        isShield = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, gameObject.transform.localPosition, Quaternion.identity);
            Destroy(gameObject);
            GameManager.instance.GetComponent<PlayerCount>().countPlayer();
            if (GameManager.instance.GetComponent<PlayerCount>().numberPlayers  <= 1)
            {
                GameManager.instance.WinGame();
            }
        }
    }

    public void decreaseHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void incrementHealth(int health)
    {
        if (currentHealth < maxHealth && currentHealth > 0)
        {
            //forse va distrutto dopo che viene istanziato l'effetto
           
            currentHealth = currentHealth + health;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            Debug.Log("curato nemico" + currentHealth);
            healthBar.SetHealth(currentHealth);
            Instantiate(healingEffect, gameObject.transform.localPosition, Quaternion.identity);
        }
    }


}

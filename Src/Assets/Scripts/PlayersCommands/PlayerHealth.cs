using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isAlive;
    public bool isShield;

    [SerializeField]
    private GameObject deathEffect;
    [SerializeField]
    private GameObject healingEffect;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        isShield = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, gameObject.transform.localPosition, Quaternion.identity);
            Destroy(gameObject);
            GameManager.instance.GetComponent<PlayerCount>().countPlayer();
            isAlive = false;
            GameManager.instance.LoseGame();

        }
        else
        {
            isAlive = true;
            //da spostare nello script Game Manager che gestirà la schermata di fine partita
        }
    }

    public void decreaseHealth(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

    }
    public void setHealth(int health)
    {
        currentHealth = health;
    }
    public void incrementHealth(int health)
    {
        if (currentHealth < maxHealth && currentHealth > 0)
        {
            //forse va distrutto dopo che viene istanziato l'effetto
            Instantiate(healingEffect, gameObject.transform.localPosition, Quaternion.identity);
            currentHealth += health - ((currentHealth+health)%maxHealth);
        }
    }
}

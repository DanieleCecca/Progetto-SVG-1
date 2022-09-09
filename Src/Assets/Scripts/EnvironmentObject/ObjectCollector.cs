using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField]
    private CoinCounter coinCounter;
    [SerializeField]
    private Shield shield;
    [SerializeField]
    private PlayerHealth playerhealth;
    [SerializeField]
    private CollisionBullet collisionbullet;
    [SerializeField]
    private Button btn;
    [SerializeField]
    private AudioClip coinSound, powerupSound;
    private bool activated = false;
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
        //inizializzo le reference
        btn = GameObject.Find("PowerUpButton").GetComponent<Button>();
    }

    //Questa funzione permette al momento della collisione con la moneta o con il powerUp di richiamare nel
    //caso della moneta una funzione che aumenta il numero di monete raccolte,il quale sarà presente nello script 
    //Coin Countere e nel caso del powerUp richiamerà una ipotetica funzione che modifica delle stats,
    //presente anche essa in un altro script.Quando avviene la collisione l'oggetto raccolto viene ditrutto.
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "coin")
        {
            //coinSound.Play();
            AudioSource.PlayClipAtPoint(coinSound, collisionInfo.collider.GetComponent<Transform>().position);
            coinCounter.addCoin();
            Destroy(collisionInfo.collider.gameObject);
            coinCounter.DisplayCoin();
        }


        else if (collisionInfo.collider.tag == "shield")
        {
            //decidere se realizzare tanti tag di powerup quanti sono questi oppure trovare un altro modo tramite ID
            //realizzare una funzione che attivi il powerUp/ come  è stato fatto per coinCounter.Add
            if (activated == false)
            {
                //powerupSound.Play();
                AudioSource.PlayClipAtPoint(powerupSound, collisionInfo.collider.GetComponent<Transform>().position);
                Destroy(collisionInfo.collider.gameObject);
                activated = true;

                //poichè voglio cambiare l'immagine che ho come figlio del bottone e poichè GetChildComponent
                //usa DFS e quindi ritorna l'immagine del bottone creo un vettore e trovo il primo figlio
                //diverso dal padre
                Image buttonImage = btn.GetComponent<Image>();
                Image[] images = btn.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                {
                    if (image != buttonImage)
                    {
                        image.sprite = collisionInfo.collider.gameObject.GetComponent<Image>().sprite;
                        image.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }

                btn.gameObject.SetActive(true);

                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(ActiveShield);
                

            }
        }
        else if (collisionInfo.collider.tag == "health")
        {
            if (activated == false)
            {
                //powerupSound.Play();
                AudioSource.PlayClipAtPoint(powerupSound, collisionInfo.collider.GetComponent<Transform>().position);
                Destroy(collisionInfo.collider.gameObject);
                activated = true;

                Image buttonImage = btn.GetComponent<Image>();
                Image[] images = btn.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                {
                    if (image != buttonImage)
                    {
                        image.sprite = collisionInfo.collider.gameObject.GetComponent<Image>().sprite; ;
                        image.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }

                btn.gameObject.SetActive(true);

                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(incrementHealth);

            }
        }
        else if (collisionInfo.collider.tag == "boostDmg")
        {
            if (activated == false)
            {
                //powerupSound.Play();
                AudioSource.PlayClipAtPoint(powerupSound, collisionInfo.collider.GetComponent<Transform>().position);
                Destroy(collisionInfo.collider.gameObject);
                activated = true;

                Image buttonImage = btn.GetComponent<Image>();
                Image[] images = btn.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                {
                    if (image != buttonImage)
                    {
                        image.sprite = collisionInfo.collider.gameObject.GetComponent<Image>().sprite; ;
                        image.color = new Color(255, 255, 255, 255);
                        break;
                    }
                }

                btn.gameObject.SetActive(true);

                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(boostBulletDamage);

            }
        }
    }

    void boostBulletDamage()
    {
        boostDmg.ActiveBoost();
        int newDamage = 33;
        collisionbullet.boostBulletDamage(newDamage);
        activated = false;
        
        btn.gameObject.SetActive(false);
        Invoke("DisableBoost", CollisionBullet.time);


    }

    //bisogna creare per forza questa funzione per usare invoke
    void DisableBoost()
    {
        boostDmg.DisableBoost();
    }

    void incrementHealth()
    {
        int healthPoints = 33;
        playerhealth.incrementHealth(healthPoints);
        activated = false;
        btn.gameObject.SetActive(false);

    }
    void ActiveShield()
    {
        shield.ActiveShield();
        activated = false;
        btn.gameObject.SetActive(false);
    }
}
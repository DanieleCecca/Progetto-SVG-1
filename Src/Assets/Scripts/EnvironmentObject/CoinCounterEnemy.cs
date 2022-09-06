using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounterEnemy : MonoBehaviour
{
    //mettere privata quando si implementa UI il public serve per vedere se raccoglie veramente
    //poichè compare su unity
    public int numberCoin = 0;
    public GameObject coin;
    public List<GameObject> coinsCollected = new List<GameObject>();

    public void addCoin()
    {
        numberCoin++;
        GameObject cloneCoin = new GameObject("cloneCoin");
        coinsCollected.Add(cloneCoin);
    }

    public void loseCoinOnDash(int lostCoins, GameObject player)
    {
        Vector3 collisionPosition = player.GetComponent<Transform>().localPosition;
        Vector3 offset = new Vector3(10, 0, 10);
        for (int i = 0; i < lostCoins; i++)
        {
            numberCoin--;
            coinsCollected.RemoveAt(numberCoin);
            Instantiate(coin, collisionPosition, Quaternion.identity);
            collisionPosition += offset;
        }
    }

}

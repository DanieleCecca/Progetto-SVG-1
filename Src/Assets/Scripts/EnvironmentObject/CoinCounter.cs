using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    //mettere privata quando si implementa UI il public serve per vedere se raccoglie veramente
    //poichè compare su unity
    public int numberCoin = 0;
    [SerializeField]
    private TextMeshProUGUI coinText;
    [SerializeField]
    private TextMeshProUGUI coinGained;
    public GameObject coin;
    public List<GameObject> coinsCollected = new List<GameObject>();

    private void Awake()
    {
        //inizializzo le reference
        coinText = GameObject.Find("Coins").GetComponent<TextMeshProUGUI>();
    }
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
        DisplayCoin();
    }

    public void DisplayCoin()
    {
        coinText.text = "Coins: " + numberCoin.ToString();
        coinGained.text = numberCoin.ToString();
    }

   
}

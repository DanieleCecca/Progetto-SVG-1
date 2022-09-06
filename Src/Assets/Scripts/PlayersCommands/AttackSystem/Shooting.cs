using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject attackPoint;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    private int maxBullet = 10;
    [SerializeField]
    private TextMeshProUGUI textAmmo;


    public Button shootButton;
    private Button btn;


    private void Awake()
    {
        shootButton = GameObject.Find("ShootingButton").GetComponent<Button>();
        textAmmo = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();

    }

    // Start is called before the first frame update
    void Start()
    {
        textAmmo.text = maxBullet.ToString();
        btn = shootButton.GetComponent<Button>();
        attackPoint.GetComponent<MeshRenderer>().enabled = false;
        btn.onClick.AddListener(ShootFuction);
    }

    // Update is called once per frame
    void Update()
    {
        //btn.onClick.AddListener(ShootFuction);
        //btn.onClick.RemoveAllListeners();
    }
    void ShootFuction()
    {
        Debug.Log("Mouse 0");
        if (maxBullet > 0)
        {
            GameObject CurrentBullet = Instantiate(bullet, attackPoint.GetComponent<Transform>().position + new Vector3(0, 0, 0.5f), attackPoint.GetComponent<Transform>().rotation);
            CurrentBullet.GetComponent<CollisionBullet>().player = gameObject;
            maxBullet--;
            textAmmo.text = maxBullet.ToString();
        }
    }
}
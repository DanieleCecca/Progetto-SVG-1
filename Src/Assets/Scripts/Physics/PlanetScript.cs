using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class PlanetScript : MonoBehaviour
{
    [SerializeField]
    private float gravity = 12f;

    [SerializeField]
    private float autoOrientSpeed = 50f;

    public void Attract(Transform playerTransform)
    {
        Vector3 diff = (playerTransform.position - transform.position).normalized; //differenza tra la nostra posizione e il centro di massa del nostro pianeta
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(diff * gravity);  //direzione * gravità negativo perchè stiamo puntando verso il basso

        Quaternion OrientationRotation = Quaternion.FromToRotation(localUp, diff) * playerTransform.rotation; //Determina quanto dobbiamo ruotare l'oggetto
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, OrientationRotation, autoOrientSpeed * Time.deltaTime); //Smoothly rotate l'ogetto per matchare l'orientamento corretto
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
*/

public class PlanetScript : MonoBehaviour
{
    [SerializeField]
    private float gravity = -12;

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        playerTransform.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        //parte che serve per ruotare il corpo dell'ggetto verso il lato giusto, i modo tale che sia piano rispetto alla superficie della sfera
        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
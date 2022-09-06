using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour

{
    [SerializeField]
    private PlanetScript attractorPlanet;
    private Transform objectTransform;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        objectTransform = transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(objectTransform);
        }
        
    }
}

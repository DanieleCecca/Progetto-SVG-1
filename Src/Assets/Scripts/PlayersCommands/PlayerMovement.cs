using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{/*
    public Rigidbody rb;
    public float speedHorizontl = 10f;
    public float speedVertical = 5f;
    public float vertical =0f;
    public float horizontal=0f;
    Vector3 moveDirection;
    Vector3 moveRotation;
    [SerializeField]
    public float rotationSpeed =0f;
    // Update is called once per frame
    void Update()
    {
        //horizontal =Input.GetAxis("Horizontal") * speedHorizontl * Time.deltaTime;
        TouchMovement();
        vertical = Input.GetAxis("Vertical") * speedVertical * Time.deltaTime;
        //vertical = 1 * speedVertical * Time.deltaTime;
        moveDirection = new Vector3(0, 0, vertical);
        moveRotation = new Vector3(horizontal, 0, 0);
        //moveDirection.Normalize();
        //moveRotation.Normalize();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDirection));
 
        if (moveRotation != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveRotation, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                horizontal = 1 * speedHorizontl * Time.deltaTime;
            }
            if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                horizontal = -1 * speedHorizontl * Time.deltaTime;
            }
        }
    } 
    */

    //movimento
    [SerializeField]
    private float speedVertical = 10f;
    [SerializeField]
    private float rotationSpeed = 10f;

    private float rotation;
    private float horizontal;
    private Rigidbody rb;

    [SerializeField]
    private float thrust = 70f;
    
    //audio
    [SerializeField]
    private AudioSource audioCarEngine;


    public AudioSource getAudioCarEngine()
    {
        return audioCarEngine;
    }

    public float getSpeed()
    {
        return speedVertical;
    }

    public void setSpeed(float newSpeed)
    {
        speedVertical = newSpeed;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //audioCarEngine.Play();
    }

    void Update()
    {
        //rotation = TouchMovement();
        // comandi touch sono stati commentati per poter provare il gioco da pc
        horizontal = Input.GetAxis("Horizontal") * (rotationSpeed / 4) * Time.fixedDeltaTime;
        //ferma l'audio di gioco a fine game;
        if (GameManager.instance.GetComponent<PauseGameplay>().isPaused == true)
        {
            audioCarEngine.Pause();
        }
        else
        {
            if(!audioCarEngine.isPlaying)
            {
                audioCarEngine.Play();
            }

        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speedVertical * Time.fixedDeltaTime);
        //Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Vector3 yRotation = Vector3.up * horizontal * rotationSpeed * Time.fixedDeltaTime; // comandi da pc
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
        transform.Rotate(0f, horizontal * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self); // comandi da pc
    }

    private int TouchMovement()
    {
        int rotation = 0;

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).position.y > Screen.height/4)
            {
                rotation = 1;
            }
            if (Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(0).position.y > Screen.height/4)
            {
                rotation = -1;
            }
        }
        return rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Vector3 bumpVector = rb.transform.;
        if (collision.gameObject.tag == "enemy")
        {
            rb.AddForce(-transform.localPosition.x * thrust, 0, -transform.localPosition.z * thrust, ForceMode.Impulse);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Mover : MonoBehaviour
{
    private bool APressed;
    private bool SPressed;
    private bool WPressed;
    private bool DPressed;
    private Rigidbody rigidBodyComponent;
    private Rigidbody parentRigidbodyComponent;
    private Rigidbody player2RigidBody;
    private Camera cam;
    private Player1Spin spinScript;
    private float health;
    
    // Start is called before the first frame update
    [SerializeField]
     public float movmentSensitivity = 500f;

    // Current rotation
    private Vector3 m_currentRotation;

    void Start()
    {
        parentRigidbodyComponent = GetComponentInParent<Rigidbody>();
        this.rigidBodyComponent = GetComponent<Rigidbody>();
       // Cursor.lockState = CursorLockMode.Locked;
        cam = this.gameObject.GetComponentInChildren<Camera>();
        player2RigidBody = GameObject.FindGameObjectsWithTag("Player2")[0].GetComponent<Rigidbody>();
        spinScript = FindObjectOfType<Player1Spin>();
        health = 100;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.W) && health > 0)
        {
            WPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.A) && health > 0)
        {
            APressed = true;
        }
         if(Input.GetKeyDown(KeyCode.S) && health > 0)
        {
            SPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.D) && health > 0)
        {
            DPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.W) && health > 0)
        {
            rigidBodyComponent.AddForce(cam.transform.forward*0,ForceMode.Impulse);
            WPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.A) && health > 0)
        {
            rigidBodyComponent.AddForce(-cam.transform.right*0,ForceMode.Impulse);
            APressed = false;
        }
         if(Input.GetKeyUp(KeyCode.S) && health > 0)
        {
            rigidBodyComponent.AddForce(-cam.transform.forward*0,ForceMode.Impulse);
            SPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.D) && health > 0)
        {
            rigidBodyComponent.AddForce(cam.transform.right*0,ForceMode.Impulse);
            DPressed = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        if(WPressed)
        {
            rigidBodyComponent.AddForce(movementVector*movmentSensitivity,ForceMode.Impulse);
           // rigidBodyComponent.AddForce(cam.transform.forward*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
           // rigidBodyComponent.AddForce(parentRigidbodyComponent.transform.forward, ForceMode.Impulse);
        }
        if(APressed)
        {
            rigidBodyComponent.AddForce(-cam.transform.right*movmentSensitivity,ForceMode.Impulse);
           // rigidBodyComponent.AddForce(-cam.transform.right*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
        }
        if(SPressed)
        {
            rigidBodyComponent.AddForce(-movementVector*movmentSensitivity,ForceMode.Impulse);
            //rigidBodyComponent.AddForce(-cam.transform.forward*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
        }
        if(DPressed)
        {
            rigidBodyComponent.AddForce(cam.transform.right*movmentSensitivity,ForceMode.Impulse);
           // rigidBodyComponent.AddForce(cam.transform.right*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
        }
    }

void OnCollisionEnter (Collision collision) {
    if (collision.gameObject.tag == "Player2")
        {
            if(rigidBodyComponent.velocity.magnitude < player2RigidBody.velocity.magnitude)
            {
                spinScript.setDamage(player2RigidBody.velocity.magnitude/3);
                this.health -= player2RigidBody.velocity.magnitude/3;
            }
            else
            {
                 spinScript.setDamage(player2RigidBody.velocity.magnitude/6);
                this.health -= player2RigidBody.velocity.magnitude/6;
            }
        }

    }
}
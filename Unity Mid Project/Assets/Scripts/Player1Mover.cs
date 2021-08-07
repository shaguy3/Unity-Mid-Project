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
    private Camera cam;

    
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
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.W))
        {
            WPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            APressed = true;
        }
         if(Input.GetKeyDown(KeyCode.S))
        {
            SPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            DPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            rigidBodyComponent.AddForce(cam.transform.forward*0,ForceMode.Impulse);
            WPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            rigidBodyComponent.AddForce(-cam.transform.right*0,ForceMode.Impulse);
            APressed = false;
        }
         if(Input.GetKeyUp(KeyCode.S))
        {
            rigidBodyComponent.AddForce(-cam.transform.forward*0,ForceMode.Impulse);
            SPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.D))
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
            rigidBodyComponent.AddForce(movementVector,ForceMode.Impulse);
           // rigidBodyComponent.AddForce(cam.transform.forward*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
           // rigidBodyComponent.AddForce(parentRigidbodyComponent.transform.forward, ForceMode.Impulse);
        }
        if(APressed)
        {
            rigidBodyComponent.AddForce(-cam.transform.right,ForceMode.Impulse);
           // rigidBodyComponent.AddForce(-cam.transform.right*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
        }
        if(SPressed)
        {
            rigidBodyComponent.AddForce(-movementVector,ForceMode.Impulse);
            //rigidBodyComponent.AddForce(-cam.transform.forward*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
        }
        if(DPressed)
        {
            rigidBodyComponent.AddForce(cam.transform.right,ForceMode.Impulse);
           // rigidBodyComponent.AddForce(cam.transform.right*Time.deltaTime*movmentSensitivity,ForceMode.VelocityChange);
        }
    }
}
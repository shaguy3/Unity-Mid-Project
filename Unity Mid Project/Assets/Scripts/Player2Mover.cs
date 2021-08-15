using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Mover : MonoBehaviour
{
    private bool m_APressed;
    private bool m_SPressed;
    private bool m_WPressed;
    private bool m_DPressed;
    private Rigidbody m_rigidBodyComponent;
    private Rigidbody m_parentRigidbodyComponent;
    private Rigidbody m_player1RigidBody;
    private Camera m_cam;
    private Player2Spin m_spinScript;
    public P2Healthbar m_healthBar;
    private Vector3 m_respawnPlayerPosition;
    private Vector3 m_respawnRotatorPosition;
    private Transform m_Rotator;
    public GameMainScript m_mainScript;
    
    [SerializeField]
     public float movmentSensitivity = 500f;

    private Vector3 m_currentRotation;

    void Start()
    {
        m_Rotator = GameObject.FindGameObjectsWithTag("Player2Rotator")[0].transform;
        m_parentRigidbodyComponent = GetComponentInParent<Rigidbody>();
        this.m_rigidBodyComponent = GetComponent<Rigidbody>();
        m_cam = this.gameObject.GetComponentInChildren<Camera>();
        m_player1RigidBody = GameObject.FindGameObjectsWithTag("Player1")[0].GetComponent<Rigidbody>();
        m_spinScript = FindObjectOfType<Player2Spin>();
        m_healthBar.SetMaxHealth(100);
        m_respawnPlayerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_respawnRotatorPosition = new Vector3(m_Rotator.position.x, m_Rotator.position.y, m_Rotator.position.z);
    }

    [System.Obsolete]
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.UpArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_WPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_APressed = true;
        }
         if(Input.GetKeyDown(KeyCode.DownArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_SPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_DPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(m_cam.transform.forward*0,ForceMode.Impulse);
            m_WPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(-m_cam.transform.right*0,ForceMode.Impulse);
            m_APressed = false;
        }
         if(Input.GetKeyUp(KeyCode.DownArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(-m_cam.transform.forward*0,ForceMode.Impulse);
            m_SPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(m_cam.transform.right*0,ForceMode.Impulse);
            m_DPressed = false;
        }

        // Falling from the arena
        if (transform.position.y < -60)
        {
            m_spinScript.Fall();
            m_healthBar.SetHealth(0);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(m_cam.transform.forward.x, 0, m_cam.transform.forward.z);
        if(m_WPressed)
        {
            m_rigidBodyComponent.AddForce(movementVector*movmentSensitivity,ForceMode.Impulse);
        }
        if(m_APressed)
        {
            m_rigidBodyComponent.AddForce(-m_cam.transform.right*movmentSensitivity,ForceMode.Impulse);
        }
        if(m_SPressed)
        {
            m_rigidBodyComponent.AddForce(-movementVector*movmentSensitivity,ForceMode.Impulse);
        }
        if(m_DPressed)
        {
            m_rigidBodyComponent.AddForce(m_cam.transform.right*movmentSensitivity,ForceMode.Impulse);
        }
    }

    void OnCollisionEnter (Collision collision) {
    if (collision.gameObject.tag == "Player1")
        {
            if(m_rigidBodyComponent.velocity.magnitude < m_player1RigidBody.velocity.magnitude)
            {
                m_spinScript.setDamage(m_player1RigidBody.velocity.magnitude/3);
                m_healthBar.SetHealth((int)m_healthBar.m_HealthBarSlider.value -
                                    (int)m_player1RigidBody.velocity.magnitude/3);
            }
            else
            {
                 m_spinScript.setDamage(m_player1RigidBody.velocity.magnitude/6);
                m_healthBar.SetHealth((int)m_healthBar.m_HealthBarSlider.value -
                                    (int)m_player1RigidBody.velocity.magnitude/6);
            }
        }

    }

    public void Respawn()
    {
        Quaternion FixCameraRotation = Quaternion.identity;
        FixCameraRotation.eulerAngles = new Vector3(0, -90, 0);
        GameObject.FindGameObjectsWithTag("Player2Obj")[0].transform.eulerAngles = new Vector3(-90,0,0);
        this.transform.position = new Vector3(m_respawnPlayerPosition.x, m_respawnPlayerPosition.y, m_respawnPlayerPosition.z);
        m_healthBar.SetHealth(100);
        m_rigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotation;
        m_Rotator.transform.position = new Vector3(m_respawnRotatorPosition.x, m_respawnRotatorPosition.y, m_respawnRotatorPosition.z);   
        m_Rotator.transform.rotation = FixCameraRotation;
        m_rigidBodyComponent.velocity = Vector3.zero;
        m_spinScript.Reset();
        m_mainScript.PlayerOneAddScore();
    }
}

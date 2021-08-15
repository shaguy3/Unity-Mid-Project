using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Mover : MonoBehaviour
{
    private bool m_APressed;
    private bool m_SPressed;
    private bool m_WPressed;
    private bool m_DPressed;
    private Rigidbody m_rigidBodyComponent;
    private Rigidbody m_parentRigidbodyComponent;
    private Rigidbody m_player2RigidBody;
    private Camera m_cam;
    private Player1Spin m_spinScript;
    private AudioSource m_scrapingSound;
    private bool m_SoundEffect;
    public P1Healthbar m_healthBar;
    private Vector3 m_respawnPlayerPosition;
    private Vector3 m_respawnRotatorPosition;
    private Transform m_Rotator;
    public GameMainScript m_mainScript;

    [SerializeField]
    public float movmentSensitivity = 500f;

    private Vector3 m_currentRotation;

    void Start()
    {
        m_Rotator = GameObject.FindGameObjectsWithTag("Player1Rotator")[0].transform;
        m_parentRigidbodyComponent = GetComponentInParent<Rigidbody>();
        this.m_rigidBodyComponent = GetComponent<Rigidbody>();
        m_cam = this.gameObject.GetComponentInChildren<Camera>();
        m_player2RigidBody = GameObject.FindGameObjectsWithTag("Player2")[0].GetComponent<Rigidbody>();
        m_spinScript = FindObjectOfType<Player1Spin>();
        m_healthBar.SetMaxHealth(100);
        m_scrapingSound = GetComponent<AudioSource>();
        m_SoundEffect = false;
        m_respawnPlayerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_respawnRotatorPosition = new Vector3(m_Rotator.position.x, m_Rotator.position.y, m_Rotator.position.z);
    }

    [System.Obsolete]
    void Update()
    {   
        if(m_SoundEffect)
        {
            m_scrapingSound.Play();   
            m_SoundEffect = false;
        }
        if(Input.GetKeyDown(KeyCode.W) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_WPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.A) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_APressed = true;
        }
         if(Input.GetKeyDown(KeyCode.S) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_SPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.D) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_DPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.W) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(m_cam.transform.forward*0,ForceMode.Impulse);
            m_WPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.A) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(-m_cam.transform.right*0,ForceMode.Impulse);
            m_APressed = false;
        }
         if(Input.GetKeyUp(KeyCode.S) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            m_rigidBodyComponent.AddForce(-m_cam.transform.forward*0,ForceMode.Impulse);
            m_SPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.D) && m_healthBar.m_HealthBarSlider.value > 0)
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
    if (collision.gameObject.tag == "Player2")
        {
            m_SoundEffect = true;
            if(m_rigidBodyComponent.velocity.magnitude < m_player2RigidBody.velocity.magnitude)
            {
                m_spinScript.setDamage(m_player2RigidBody.velocity.magnitude/3);
                m_healthBar.SetHealth((int)m_healthBar.m_HealthBarSlider.value - 
                                    (int)m_player2RigidBody.velocity.magnitude/3);
            }
            else
            {
                m_spinScript.setDamage(m_player2RigidBody.velocity.magnitude/6);
                m_healthBar.SetHealth((int)m_healthBar.m_HealthBarSlider.value - 
                                    (int)m_player2RigidBody.velocity.magnitude/6);
            }
        }

    }

public void Respawn()
{
    this.transform.position = new Vector3(m_respawnPlayerPosition.x, m_respawnPlayerPosition.y, m_respawnPlayerPosition.z);
    GameObject.FindGameObjectsWithTag("Player1Obj")[0].transform.eulerAngles = new Vector3(-90,0,0);
    m_healthBar.SetHealth(100);
    m_rigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotation;
    m_Rotator.transform.position = new Vector3(-90.3f, -33.4f, 9.77541f);
    GameObject.FindGameObjectsWithTag("Player1Obj")[0].transform.position = new Vector3(-109.5f, -29.5f, 12.4754f);
    m_Rotator.transform.rotation = Quaternion.identity;
    m_rigidBodyComponent.velocity = Vector3.zero;
    m_spinScript.Reset();
    m_mainScript.PlayerTwoAddScore();
}

}


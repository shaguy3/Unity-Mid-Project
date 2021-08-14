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
    private AudioSource scrapingSound;
    private bool SoundEffect;
    public P1Healthbar m_healthBar;
    private Vector3 m_respawnPlayerPosition;
    private Vector3 m_respawnRotatorPosition;
    private Transform Rotator;


    // Start is called before the first frame update
    [SerializeField]
    public float movmentSensitivity = 500f;

    // Current rotation
    private Vector3 m_currentRotation;

    void Start()
    {
        Rotator = GameObject.FindGameObjectsWithTag("Player1Rotator")[0].transform;
        parentRigidbodyComponent = GetComponentInParent<Rigidbody>();
        this.rigidBodyComponent = GetComponent<Rigidbody>();
       // Cursor.lockState = CursorLockMode.Locked;
        cam = this.gameObject.GetComponentInChildren<Camera>();
        player2RigidBody = GameObject.FindGameObjectsWithTag("Player2")[0].GetComponent<Rigidbody>();
        spinScript = FindObjectOfType<Player1Spin>();
        m_healthBar.SetMaxHealth(100);
        scrapingSound = GetComponent<AudioSource>();
        SoundEffect = false;
        m_respawnPlayerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        m_respawnRotatorPosition = new Vector3(Rotator.position.x, Rotator.position.y, Rotator.position.z);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {   
        if(SoundEffect)
        {
            scrapingSound.Play();   
            SoundEffect = false;
        }
        if(Input.GetKeyDown(KeyCode.W) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            WPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.A) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            APressed = true;
        }
         if(Input.GetKeyDown(KeyCode.S) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            SPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.D) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            DPressed = true;
        }

        if(Input.GetKeyUp(KeyCode.W) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            rigidBodyComponent.AddForce(cam.transform.forward*0,ForceMode.Impulse);
            WPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.A) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            rigidBodyComponent.AddForce(-cam.transform.right*0,ForceMode.Impulse);
            APressed = false;
        }
         if(Input.GetKeyUp(KeyCode.S) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            rigidBodyComponent.AddForce(-cam.transform.forward*0,ForceMode.Impulse);
            SPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.D) && m_healthBar.m_HealthBarSlider.value > 0)
        {
            rigidBodyComponent.AddForce(cam.transform.right*0,ForceMode.Impulse);
            DPressed = false;
        }

        // Falling from the arena
        if (transform.position.y < -60)
        {
            spinScript.Fall();
            m_healthBar.SetHealth(0);
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
            SoundEffect = true;
            if(rigidBodyComponent.velocity.magnitude < player2RigidBody.velocity.magnitude)
            {
                spinScript.setDamage(player2RigidBody.velocity.magnitude/3);
                m_healthBar.SetHealth((int)m_healthBar.m_HealthBarSlider.value - 
                                    (int)player2RigidBody.velocity.magnitude/3);
            }
            else
            {
                spinScript.setDamage(player2RigidBody.velocity.magnitude/6);
                m_healthBar.SetHealth((int)m_healthBar.m_HealthBarSlider.value - 
                                    (int)player2RigidBody.velocity.magnitude/6);
            }
        }

    }

public void Respawn()
{
    this.transform.position = new Vector3(m_respawnPlayerPosition.x, m_respawnPlayerPosition.y, m_respawnPlayerPosition.z);
    GameObject.FindGameObjectsWithTag("Player1Obj")[0].transform.eulerAngles = new Vector3(-90,0,0);
    m_healthBar.SetHealth(100);
    rigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotation;
   // Rotator.transform.position = new Vector3(m_respawnRotatorPosition.x, m_respawnRotatorPosition.y, m_respawnRotatorPosition.z);
    Rotator.transform.position = new Vector3(-90.3f, -33.4f, 9.77541f);  
    GameObject.FindGameObjectsWithTag("Player1Obj")[0].transform.position = new Vector3(-109.5f, -29.5f, 12.4754f);
    Rotator.transform.rotation = Quaternion.identity;
    rigidBodyComponent.velocity = Vector3.zero;
    spinScript.Reset();
}

}


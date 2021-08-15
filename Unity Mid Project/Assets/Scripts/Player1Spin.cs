using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spin : MonoBehaviour
{
    [SerializeField]
    private float m_spinSensitivity;
    private float m_Damage;
    private Player1Mover m_PlayerOne;
    [SerializeField]
    private ParticleSystem m_sparks;
    public P1Healthbar m_healthBar;
    private bool m_isRespawn;

    void Start()
    {
        m_spinSensitivity = -100.0f;
        m_Damage = 0;
        m_PlayerOne = FindObjectOfType<Player1Mover>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        if(m_Damage < 100.0f)
        {
            transform.Rotate(0.0f, 0.0f, m_spinSensitivity+m_Damage, Space.Self);
            m_isRespawn = false;
        }
        else
        {
            gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self); //dead
            m_healthBar.SetHealth(0);
            if (!m_isRespawn)
            {
                m_PlayerOne.Invoke("Respawn", 3.0f);
                m_isRespawn = true;
            }
        }
    }

    public void setDamage(float i_damage)
    {
        Quaternion myRotation = Quaternion.identity;
        myRotation.eulerAngles = new Vector3(0, Random.Range(0f,180f), 0);
        m_Damage += i_damage;
        Instantiate(m_sparks, transform.position, myRotation);
        m_sparks.Play();
    }

    public void Fall()
    {
        m_Damage = 100;
        transform.Rotate(0.0f, 0.2f, 0.2f, Space.Self);
    }

    public void Reset()
    {
        m_spinSensitivity = -100.0f;
        m_Damage = 0;
    }
}


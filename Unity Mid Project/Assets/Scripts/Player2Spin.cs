using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spin : MonoBehaviour
{
    [SerializeField]
    private float m_SpinSensitivity;
    private float m_Damage;
    private Player2Mover m_PlayerTwo;
    public P2Healthbar m_healthBar;
    private bool m_isRespawn;

    void Start()
    {
        m_SpinSensitivity = -100.0f;
        m_Damage = 0;
        m_PlayerTwo = FindObjectOfType<Player2Mover>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(m_Damage < 100)
        {
            transform.Rotate(0.0f, 0.0f, m_SpinSensitivity + m_Damage, Space.Self);
            m_isRespawn = false;
        }
        else
        {
            gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self); //dead
            m_healthBar.SetHealth(0);
            if (!m_isRespawn)
            {
                m_PlayerTwo.Invoke("Respawn", 3.0f);
                m_isRespawn = true;
            }
        }
    }

    public void setDamage(float i_Damage)
    {
        m_Damage += i_Damage;
    }

    public void Fall()
    {
        m_Damage = 100;
        transform.Rotate(0.0f, 0.2f, 0.2f, Space.Self);
    }

    public void Reset()
    {
        m_SpinSensitivity = -100.0f;
        m_Damage = 0;
    }
}


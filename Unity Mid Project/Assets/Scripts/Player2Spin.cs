using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Spin : MonoBehaviour
{
    [SerializeField]
    private float m_SpinSensitivity;
    private float m_Damage;
    private Player2Mover p2;
    // Start is called before the first frame update
    void Start()
    {
        m_SpinSensitivity = -100.0f;
        m_Damage = 0;
         p2 = FindObjectOfType<Player2Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(m_Damage < 100)
        {
            transform.Rotate(0.0f, 0.0f, m_SpinSensitivity+m_Damage, Space.Self);
        }
        else
        {
            gameObject.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self); //dead
            p2.Respawn();
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


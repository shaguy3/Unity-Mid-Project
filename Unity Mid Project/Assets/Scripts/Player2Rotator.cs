using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Rotator : MonoBehaviour
{
    [SerializeField]
    private float m_RotationSpeed;
    private float m_Rotation;
    private GameObject m_PlayerTwo;

    private bool m_LeftRotation = false, m_RightRotation = false;

    void Start()
    {
        m_RotationSpeed = 100;
        m_PlayerTwo = GameObject.FindGameObjectsWithTag("Player2Obj")[0];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            m_LeftRotation = true;
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            m_RightRotation = true;
        }

        if(Input.GetKeyUp(KeyCode.K))
        {
            m_LeftRotation = false;
        }

        if(Input.GetKeyUp(KeyCode.L))
        {
            m_RightRotation = false;
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if(m_LeftRotation)
        {
            m_Rotation = -1 * m_RotationSpeed * Time.deltaTime;
        }
        if(m_RightRotation)
        {
            m_Rotation = m_RotationSpeed * Time.deltaTime;
        }

        if(!m_LeftRotation && !m_RightRotation)
        {
            m_Rotation = 0;
            transform.RotateAround(m_PlayerTwo.transform.position, new Vector3(0.0f,1.0f,0.0f), m_Rotation);
        }
        transform.RotateAround(m_PlayerTwo.transform.position, new Vector3(0.0f,1.0f,0.0f), m_Rotation * 1.5f);
    }
}

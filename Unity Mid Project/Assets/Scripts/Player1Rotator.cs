using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Rotator : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    private float m_Rotation;
    private GameObject m_PlayerOne;

    private bool m_LeftRotation = false, m_RightRotation = false;

    void Start()
    {
        m_Speed = 100;
        m_PlayerOne = GameObject.FindGameObjectsWithTag("Player1Obj")[0];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            m_LeftRotation = true;
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            m_RightRotation = true;
        }

        if(Input.GetKeyUp(KeyCode.C))
        {
            m_LeftRotation = false;
        }

        if(Input.GetKeyUp(KeyCode.V))
        {
            m_RightRotation = false;
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        if(m_LeftRotation)
        {
            m_Rotation = -1 * m_Speed * Time.deltaTime;
        }
        if(m_RightRotation)
        {
            m_Rotation = m_Speed * Time.deltaTime;
        }

        if(!m_LeftRotation && !m_RightRotation)
        {
            m_Rotation = 0;
            transform.RotateAround(m_PlayerOne.transform.position, new Vector3(0.0f,1.0f,0.0f), m_Rotation);
        }
        transform.RotateAround(m_PlayerOne.transform.position, new Vector3(0.0f,1.0f,0.0f), m_Rotation * 1.5f);
    }
}

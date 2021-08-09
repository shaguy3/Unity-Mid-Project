using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    // Mouse control
    private float rotation;
    private GameObject player2;

    private bool m_LeftRotation = false, m_RightRotation = false;

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        speed = 100;
        player2 = GameObject.FindGameObjectsWithTag("Player2Obj")[0];
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

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        if(m_LeftRotation)
        {
            rotation = -1 * speed * Time.deltaTime;
        }
        if(m_RightRotation)
        {
            rotation = speed * Time.deltaTime;
        }

        if(!m_LeftRotation && !m_RightRotation)
        {
            rotation = 0;
            transform.RotateAround(player2.transform.position, new Vector3(0.0f,1.0f,0.0f), rotation);
        }
        //transform.rotation *= Quaternion.Euler(0, rotation, 0);
        transform.RotateAround(player2.transform.position, new Vector3(0.0f,1.0f,0.0f), rotation * 1.5f);
        // TODO: RotateAround?
    }וו
}

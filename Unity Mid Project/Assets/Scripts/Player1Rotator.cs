using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    // Mouse control
    private float rotation;
    private GameObject player1;
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        speed = 100;
        player1 = GameObject.FindGameObjectsWithTag("Player1Obj")[0];
    }

    // Update is called once per frame
    [System.Obsolete]
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.C))
        {
            rotation = -1 * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.V))
        {
            rotation = speed * Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.V))
        {
            rotation = 0;
            transform.RotateAround(player1.transform.position, new Vector3(0.0f,1.0f,0.0f), rotation);
        }
        //transform.rotation *= Quaternion.Euler(0, rotation, 0);
        transform.RotateAround(player1.transform.position, new Vector3(0.0f,1.0f,0.0f), rotation * 1.5f);
        // TODO: RotateAround?
    }
}
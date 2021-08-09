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
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        speed = 100;
        player2 = GameObject.FindGameObjectsWithTag("Player2Obj")[0];
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Input.GetKey(KeyCode.K))
        {
            rotation = -1 * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.L))
        {
            rotation = speed * Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.L))
        {
            rotation = 0;
            transform.RotateAround(player2.transform.position, new Vector3(0.0f,1.0f,0.0f), rotation);
        }
        //transform.rotation *= Quaternion.Euler(0, rotation, 0);
        transform.RotateAround(player2.transform.position, new Vector3(0.0f,1.0f,0.0f), rotation * 1.5f);
        
    }
}

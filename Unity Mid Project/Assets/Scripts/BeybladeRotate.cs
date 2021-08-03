using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeybladeRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    // Mouse control
    private float rotation;
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        speed = 100;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
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
            rotation = 0 * speed * Time.deltaTime;
        }
        transform.rotation *= Quaternion.Euler(0, rotation, 0);
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeybladeRotate : MonoBehaviour
{
    // Start is called before the first frame update
     public float speed;
    // Mouse control
    private float MouseX;
    public float mouseSpeed;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speed = 100;
        mouseSpeed = 100;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0, MouseX, 0);
        if(Input.GetKey(KeyCode))
    }
}

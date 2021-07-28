using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeybladeMove : MonoBehaviour
{

    private bool APressed;
    private bool SPressed;
    private bool WPressed;
    private bool DPressed;
    private bool SpacePressed;
    private Rigidbody rigidBodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            WPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            APressed = true;
        }
         if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            DPressed = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpacePressed = true;
        }

        if(Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.UpArrow))
        {
            WPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            APressed = false;
        }
         if(Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.DownArrow))
        {
            SPressed = false;
        }
        if(Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.RightArrow))
        {
            DPressed = false;
        }
    }

    private void FixedUpdate()
    {
        if(WPressed)
        {
            rigidBodyComponent.AddForce(Vector3.forward,ForceMode.Impulse);
        }
        if(APressed)
        {
        rigidBodyComponent.AddForce(Vector3.left,ForceMode.Impulse);
        }
        if(SPressed)
        {
        rigidBodyComponent.AddForce(Vector3.back,ForceMode.Impulse);
        }
        if(DPressed)
        {
        rigidBodyComponent.AddForce(Vector3.right,ForceMode.Impulse);
        }
        if(SpacePressed)
        {
            rigidBodyComponent.AddForce(Vector3.up*7,ForceMode.Impulse);
            SpacePressed = false;
        }
    }
}

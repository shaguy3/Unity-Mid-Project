using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spin : MonoBehaviour
{
    [SerializeField]
    private float spinSensitivity;
    private Rigidbody player2;
    // Start is called before the first frame update
    void Start()
    {
        spinSensitivity = -100.0f;
        player2 = GameObject.FindGameObjectsWithTag("Player2")[0].GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0.0f, 0.0f, spinSensitivity, Space.Self);
    }
    void OnCollisionEnter (Collision targetObj){
        if(targetObj.gameObject.tag == "Player2")
        {
            float damage = player2.velocity.magnitude;
            Debug.Log(damage);
        }
    }
}


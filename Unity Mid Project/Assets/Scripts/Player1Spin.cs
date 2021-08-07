using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spin : MonoBehaviour
{
    [SerializeField]
    private float spinSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        spinSensitivity = -100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0.0f, 0.0f, spinSensitivity, Space.Self);
    }
}


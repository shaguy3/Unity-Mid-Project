using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Spin : MonoBehaviour
{
    [SerializeField]
    private float spinSensitivity;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        spinSensitivity = -100.0f;
        damage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(damage < 100)
        {
            transform.Rotate(0.0f, 0.0f, spinSensitivity+damage, Space.Self);
        }
        else
        {
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self); //dead
        }
        
    }

    public void setDamage(float dmg){damage += dmg;}
}


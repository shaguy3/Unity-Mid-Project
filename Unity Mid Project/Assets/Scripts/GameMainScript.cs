using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainScript : MonoBehaviour
{
    private int m_Player1Score;
    private int m_Player2Score;


    // Start is called before the first frame update
    void Start()
    {
        m_Player1Score = 0;
        m_Player2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if the health is 0, start over.
    }
}

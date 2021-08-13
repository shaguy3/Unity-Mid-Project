using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainScript : MonoBehaviour
{
    private int m_Player1Score;
    private int m_Player2Score;
    private P1Healthbar m_healthBarPlayer1;
    private P2Healthbar m_healthBarPlayer2;
    private Player1Mover m_P1;
    private Player2Mover m_p2;

    // Start is called before the first frame update
    void Start()
    {
        m_Player1Score = 0;
        m_Player2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_healthBarPlayer1.GetHealth() <= 0.0f)
        {
            m_P1.Respawn();
            m_p2.Respawn();
        }
        if(m_healthBarPlayer2.GetHealth() <= 0.0f)
        {
            m_P1.Respawn();
            m_p2.Respawn();
        }
    }
}

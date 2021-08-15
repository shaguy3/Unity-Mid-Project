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

    private GameObject[] m_playerOneScores;
    private GameObject[] m_playerTwoScores;

    void Start()
    {
        m_Player1Score = 0;
        m_Player2Score = 0;

        m_playerOneScores = GameObject.FindGameObjectsWithTag("PlayerOneScores");
        m_playerTwoScores = GameObject.FindGameObjectsWithTag("PlayerTwoScores");
    }

    void Update()
    {
        
    }

    public void PlayerOneAddScore()
    {
        m_playerOneScores[m_Player1Score].GetComponent<Image>().enabled = true;
        m_Player1Score++;
    }

    public void PlayerTwoAddScore()
    {
        m_playerTwoScores[m_Player2Score].GetComponent<Image>().enabled = true;
        m_Player2Score++;
    }
}

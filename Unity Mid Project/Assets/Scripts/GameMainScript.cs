using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        // GameObject directionalLight = GameObject.FindGameObjectsWithTag("TheSun")[0];
        // Vector3 lookingDown = new Vector3(85.3f, 91.7f, 184.5f);
        // directionalLight.transform.rotation = Quaternion.Euler(lookingDown);

        m_Player1Score = 0;
        m_Player2Score = 0;

        m_playerOneScores = GameObject.FindGameObjectsWithTag("PlayerOneScores");
        m_playerTwoScores = GameObject.FindGameObjectsWithTag("PlayerTwoScores");
    }

    void Update()
    {
        if (m_Player1Score == 3)
        {
            if (!GameObject.FindGameObjectsWithTag("PlayerTwoWon")[0].GetComponent<Text>().enabled)
            {
                GameObject.FindGameObjectsWithTag("PlayerOneWon")[0].GetComponent<Text>().enabled = true;
            }
            this.Invoke("LoadMainMenu", 3.0f);
        }
        if (m_Player2Score == 3)
        {
            if (!GameObject.FindGameObjectsWithTag("PlayerOneWon")[0].GetComponent<Text>().enabled)
            {
                GameObject.FindGameObjectsWithTag("PlayerTwoWon")[0].GetComponent<Text>().enabled = true;
            }
            this.Invoke("LoadMainMenu", 3.0f);
        }
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

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

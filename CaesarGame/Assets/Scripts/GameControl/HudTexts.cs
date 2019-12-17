using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudTexts : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI livesText = null;

    GameSession session;

    void Start()
    {
        GetTheSession();
    }

    void LateUpdate()
    {
        UpdateScores();
    }

    void UpdateScores()
    {
        if (session == null) {
            GetTheSession();
        } else {
            scoreText.text = session.score.ToString();
            livesText.text = session.lives.ToString();
        }
    }

    void GetTheSession()
    {
        session = FindObjectOfType<GameSession>();
    }

}

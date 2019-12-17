using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI), typeof(TextMeshProUGUI))]
public class HudTexts : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameSession session;
    // GameSession session;

    private void Awake()
    {
        Debug.Log("HudTexts awoken");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HudTexts Started");
        session = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(session.ToString());
        scoreText.text = session.score.ToString();
        livesText.text = session.lives.ToString();
    }
}

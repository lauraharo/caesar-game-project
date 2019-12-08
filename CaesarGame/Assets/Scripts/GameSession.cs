using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyScoreText;
    [SerializeField] int moneyScore = 0;
    void Start()
    {
        moneyScoreText.text = moneyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScore(int pointToAdd)
    {
        moneyScore += pointToAdd;
        moneyScoreText.text = moneyScore.ToString();
    }
    
}

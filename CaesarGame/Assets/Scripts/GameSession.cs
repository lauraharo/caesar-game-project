using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    [SerializeField] int lives = 2;
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScore(int pointToAdd)
    {
        score += pointToAdd;
        scoreText.text = score.ToString();
    }

    public void AddLives(int amount)
    {
        lives += amount;
    }

    public void DeleteLives(int amount)
    {
        lives -= amount;
        if (lives == -1) SceneManager.LoadScene("GameOver");
    }
    
}

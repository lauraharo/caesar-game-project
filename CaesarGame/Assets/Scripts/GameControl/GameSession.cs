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


    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
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
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ProcessPlayerDeath()
    {
        if (lives > 1){
            DeleteLives(1);
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
    }
    
}

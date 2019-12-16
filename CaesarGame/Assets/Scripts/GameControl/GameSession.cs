using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] int score = 0;
    [SerializeField] int lives = 3;


    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSessions > 1)
        {
            gameObject.SetActive(false);
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
        livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScore(int pointToAdd)
    {
        Debug.Log(gameObject.transform.position.x);
        score += pointToAdd;
        scoreText.text = score.ToString();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        livesText.text = lives.ToString();
    }

    public void DeleteLives(int amount)
    {
        lives -= amount;
        livesText.text = lives.ToString();
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
    public void ResetGameOnWin()
    {
        SceneManager.LoadScene("Winner");
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour
{
    public static GameSession instance = null;

    public int score = 0;
    public int lives = 3;

    SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = GetComponent<SceneLoader>();

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddToScore(int pointToAdd)
    {
        score += pointToAdd;
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
        if (lives > 1) DeleteLives(1);
        else sceneLoader.LoadGameOver();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneLoader))]
public class GameSession : MonoBehaviour
{

    public static GameSession instance;
    

    public const int initialLives = 3;
    public const int initialScore = 0;

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
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addToScore(int pointToAdd)
    {
        score += pointToAdd;
        //scoreText.text = score.ToString();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        
    }

    public void DeleteLives(int amount)
    {
        lives -= amount;
        //livesText.text = lives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ProcessPlayerDeath()
     {
        Debug.Log("Processing player death");
        if (lives > 1){
            DeleteLives(1);
        }
        else
        {
            sceneLoader.LoadGameOver();
        }
    }
}

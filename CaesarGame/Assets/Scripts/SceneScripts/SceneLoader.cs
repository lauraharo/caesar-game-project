using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    ScenePersist persistor;
    GameSession session;

    private void Start()
    {
        persistor = FindObjectOfType<ScenePersist>();
        session = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        DestroyPersistor();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadWinner()
    {
        DestroyPersistor();
        SceneManager.LoadScene("Winner");
    }

    public void LoadGameOver()
    {
        DestroyPersistorAndGameSession();
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartScene()
    {
        DestroyPersistorAndGameSession();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        DestroyPersistorAndGameSession();
        Application.Quit();
    }

    public void LoadAlicia() {
        DestroyPersistor();
        SceneManager.LoadScene("AliciaFight");
    }

    void DestroyPersistor()
    {
        if (persistor != null) Destroy(persistor.gameObject);
    }

    void DestroyPersistorAndGameSession() {
        if (persistor != null) Destroy(persistor.gameObject);
        if (session != null) Destroy(session.gameObject);
    }
}

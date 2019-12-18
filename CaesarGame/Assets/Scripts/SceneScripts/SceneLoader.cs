using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    ScenePersist persistor;
    GameSession session;

    public void LoadNextScene()
    {
        DestroyPersistor();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadWinner()
    {
        DestroyPersistorAndGameSession();
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
        persistor = FindObjectOfType<ScenePersist>();
        if (persistor != null) Destroy(persistor.gameObject);
    }

    void DestroyPersistorAndGameSession() {
        persistor = FindObjectOfType<ScenePersist>();
        session = FindObjectOfType<GameSession>();
        if (persistor != null) Destroy(persistor.gameObject);
        if (session != null) Destroy(session.gameObject);
    }
}

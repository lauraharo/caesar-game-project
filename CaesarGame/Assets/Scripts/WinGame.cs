using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] GameSession session;
    [SerializeField] float levelLoadDelay = 1f;

    private void Start()
    {
        session = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(LoadWinLevel());
    }

    IEnumerator LoadWinLevel()
    {

        yield return new WaitForSecondsRealtime(levelLoadDelay);
        session.ResetGameOnWin();
    }
}

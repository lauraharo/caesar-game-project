using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader = null;
    [SerializeField] float levelLoadDelay = 1f;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(LoadWinLevel());
    }

    IEnumerator LoadWinLevel()
    {

        yield return new WaitForSecondsRealtime(levelLoadDelay);
        sceneLoader.LoadWinner();
    }
}

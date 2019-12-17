using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] SceneLoader sceneloader;


    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        sceneloader.LoadNextScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    [SerializeField] AudioClip coinPickUpSound;
    [SerializeField] int coinValue = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(coinPickUpSound, Camera.main.transform.position);
        FindObjectOfType<GameSession>().addToScore(coinValue);
        Destroy(gameObject);
    }
}

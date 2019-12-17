using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    GameObject player;
    PlayerHealth health;
    // GameSession session;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // session = FindObjectOfType<GameSession>();
        health = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test death trigger");
        if (collision.gameObject == player) {
            health.TakeDamage(health.currentHealth);
            // session.ProcessPlayerDeath();
        }
    }
}

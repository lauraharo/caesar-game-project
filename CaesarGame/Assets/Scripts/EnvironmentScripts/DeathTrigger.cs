using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    PlayerHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(health.currentHealth);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // public variables
    public int hitDamage = 10;

    // private variables
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    GameObject player;
    bool playerInRange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // If the entering collider is the player, then player is in range to get damaged
        if (other.gameObject == player) {
            playerInRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        // If the exiting collider is the player, then its no longer in range to get damaged
        if (other.gameObject == player) {
            playerInRange = false;
        }
    }


    void FixedUpdate()
    {
        // If the timer exceeds the time between attacks, the player is in range (and this enemy is alive), deal damage
        if (playerInRange && !player.GetComponent<PlayerPlatformerController>().isDead && !enemyHealth.isDead) {
            DealDamageToPlayer();
        }
    }

    // Deals damage to player
    void DealDamageToPlayer()
    {
        playerHealth.TakeDamage(hitDamage);
    }


}

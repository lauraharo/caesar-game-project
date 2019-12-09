using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // public variables
    public int hitDamage = 10;
    public float timeBetweenAttacks = 0.5f;

    // private variables
    PlayerHealth playerHealth;
    GameObject player;
    float size;
    float timer;
    bool playerInRange;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        // TODO: enemy health script
        //enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
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


    void Update()
    {
        // add time to the timer each update
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range (and this enemy is alive), deal damage
        if (timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0*/ ) {
            DealDamageToPlayer();
        }

    }

    // Deals damage to player
    void DealDamageToPlayer()
    {
        playerHealth.TakeDamage(hitDamage);
        timer = 0;
    }


}

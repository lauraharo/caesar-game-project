using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // public variables
    public int hitDamage = 10;

    // private variables
    EnemyHealth enemyHealth;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {

            DealDamageToPlayer(other.GetComponent<PlayerHealth>());
        }  
    }

    void DealDamageToPlayer(PlayerHealth player)
    {
        if (!enemyHealth.isDead) {
            player.TakeDamage(hitDamage);
        }
    }


}

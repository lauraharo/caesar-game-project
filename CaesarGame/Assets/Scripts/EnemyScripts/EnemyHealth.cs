using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int initialHealth = 1;
    [SerializeField] float invisibilityTimeFrame = 5f;
    public int currentHealth;
    public bool isDead;
    public bool damaged;         

    float flashSpeed = 1f;
    float invisibilityTime;
    public Color flashColour = new Color(1f, 1f, 1f, 0.2f);    // The colour the damageImage is set to, to flash.
    public Color flashColourSecond = new Color(1f, 1f, 1f, 1f);
    
    SpriteRenderer enemySprite;

    private void Awake()
    {
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        invisibilityTime = invisibilityTimeFrame;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = initialHealth;
        isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth <= 0 && !isDead) {
            Die();
        }

       
        // If the enemy has just been damaged
        if (damaged || isDead) {
            // ... set the colour of the damageImage to the flash colour.
            if (flashSpeed < 0) {
                enemySprite.color = flashColourSecond;
                flashSpeed = 1f;
            }
            else {
                enemySprite.color = flashColour;
            }
            flashSpeed -= 0.5f;
            invisibilityTime -= 0.1f;
            damaged = !(invisibilityTime < 0);
            
        }
        else {
            flashSpeed = 1f;
            invisibilityTime = invisibilityTimeFrame;
            enemySprite.color = flashColourSecond;
        }
    }

    public void TakeDamage(int amount) {
        if (invisibilityTime != invisibilityTimeFrame) return;
        damaged = true;
        currentHealth -= amount;
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject, 0.6f);
    }
}

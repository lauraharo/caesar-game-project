using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.

    // TODO: some of these can be used for player's sprite flash and death sound etc.
    // public AudioClip deathClip;                                 // The audio clip to play when the player dies.

    float flashSpeed = 1f;
    float invisibilityTime = 10f;                
    public Color flashColour = new Color(1f, 1f, 1f, 0.2f);    // The colour the damageImage is set to, to flash.
    public Color flashColourSecond = new Color(1f, 1f, 1f, 1f);
    bool damaged;                                               // True when the player gets damaged.

    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                    // Reference to the AudioSource component.
    PlayerPlatformerController playerMovement;                              // Reference to the player's movement. Use this to disallow movement when dead
    GameSession session;
    SpriteRenderer playerSprite;

    bool isDead;                                                // Whether the player is dead.

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        // playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerPlatformerController>();
        //playerShooting = GetComponentInChildren<PlayerShooting>();

        // Set the initial health of the player.
        currentHealth = startingHealth;
        session = FindObjectOfType<GameSession>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        // If the player has just been damaged...
        if (damaged) {
            // ... set the colour of the damageImage to the flash colour.
            if (flashSpeed < 0) {
                playerSprite.color = flashColourSecond;
                flashSpeed = 1f;
            }
            else {
                playerSprite.color = flashColour;
            }
            flashSpeed -= 0.5f;
            invisibilityTime -= 0.2f;
            if (invisibilityTime < 0) {
                damaged = false;
            }
        } else {
            flashSpeed = 1f;
            invisibilityTime = 10f;
            playerSprite.color = flashColourSecond;
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > startingHealth) currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        if (invisibilityTime != 10f) return;
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth == 0 && !isDead) {
            damaged = false;
            healthSlider.value = 0;
            playerMovement.isDead = true;
            session.ProcessPlayerDeath();
        }
    }
}
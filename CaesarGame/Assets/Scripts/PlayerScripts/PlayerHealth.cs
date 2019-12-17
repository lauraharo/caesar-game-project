﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                
    public int currentHealth = 0;                                 
    public Slider healthSlider = null;                                
    [SerializeField] float invisibilityTimeFrame = 5f;

    float flashSpeed = 1f;
    float invisibilityTime;         
    Color flashColour = new Color(1f, 1f, 1f, 0.2f);    
    Color flashColourSecond = new Color(1f, 1f, 1f, 1f);

    bool damaged;                                            
    bool isDead = false;                                                

    Animator anim;                                              
    PlayerPlatformerController playerMovement;                            
    GameSession session;
    SpriteRenderer playerSprite;


    void Awake()
    {
        // Initialize variables
        healthSlider = FindObjectOfType<Slider>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerPlatformerController>();
        invisibilityTime = invisibilityTimeFrame;
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
            invisibilityTime -= 0.1f;
            if (invisibilityTime < 0) {
                damaged = false;
            }
        } else {
            flashSpeed = 1f;
            invisibilityTime = invisibilityTimeFrame;
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
        if (invisibilityTime != invisibilityTimeFrame) return;
        // Set the damaged flag so the screen will flash.
        damaged = true;
        invisibilityTime -= 0.1f;

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
        }
    }
}
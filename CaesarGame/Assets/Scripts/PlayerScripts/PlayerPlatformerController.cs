﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject
{
    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;
    public float slideSpeed = 5f;
    public float slideLength = 5f;
    public bool isSliding, isDead;

    [SerializeField] Collider2D slideDisableCollider = null;
    [SerializeField] LayerMask whatIsGround = 1 << 8;
    [SerializeField] Transform ceilingCheck = null, meleeHitCheck = null;
    [SerializeField] float ceilingCheckRadius = 0.4f;
    [SerializeField] int initialDeathTime = 400;
    [SerializeField] float meleeRadius = 0.05f;
    [SerializeField] float timeBetweenAttacks = 10f;

    bool canStandUp, isFacingRight, respawnCalled;
    float slideTime, attackTimer;
    int deathTime;

    Vector2 move;
    Vector3 startPosition;
    PlayerHealth playerHealth;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isSliding = false;
        respawnCalled = false;
        slideDisableCollider.enabled = true;
        isFacingRight = true;
        isDead = false;
        deathTime = initialDeathTime;
        attackTimer = 0;
        startPosition = transform.position;
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    protected override void ComputeSlide()
    {
        if (isSliding) {
            slideTime = slideTime <= 0 ? 0 : slideTime - 1;
        }
    }

    protected override void ComputeVelocity()
    {
        if (move.x > 0.01f && !isFacingRight) {
            Flip();
        }
        else if (move.x < -0.01f && isFacingRight) {
            Flip();
        }

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(move.x));
        animator.SetFloat("VelocityY", velocity.y);
        animator.SetBool("IsDead", isDead);

        if (!isDead) {
            if (isSliding) HandleSlidingControls();
            else HandleControls();
        } else HandleDeath();

        targetVelocity = isSliding ? move * slideSpeed : move * maxSpeed;
        canStandUp = !Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, whatIsGround);

    }


    // All logic regarrding movement during a slide is here
    private void HandleSlidingControls() {
        if (canStandUp && slideTime <= 0) ToggleSlide();

        if (Input.GetButtonDown("Jump") && grounded && canStandUp) {
            ToggleSlide();
            HandleJumpAndSlide();
        }

        // read input: right or left keys - positive values right, negative left
        float horizontalInput = Input.GetAxis("Horizontal");

        if (!isFacingRight) {
            move.x = -0.5f;
            if (horizontalInput > 0) {
                if (!canStandUp) move.x = 0.5f;
                else ToggleSlide();
            } 
        }
        else {
            move.x = 0.5f;
            if (horizontalInput < 0) {
                if (!canStandUp) move.x = -0.5f;
                else ToggleSlide();
            }
        }
 

    }

    // All "normal" movement logic when character is not sliding
    private void HandleControls() {
        move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        HandleJumpAndSlide();

        if (attackTimer > 0 ) attackTimer -= 0.1f;
        if (attackTimer <= 0) {
            HandleAttack();
        }

        targetVelocity = move * maxSpeed;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void HandleJumpAndSlide()
    {
        
        if (Input.GetButtonDown("Jump") && grounded) {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                ToggleSlide();
            }
            else {
                velocity.y = jumpTakeOffSpeed;
                animator.SetTrigger("PlayerJump");
            }
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > jumpTakeOffSpeed / 4) {
                velocity.y = 0;
            }
        }
    }

    private void ToggleSlide()
    {
        slideTime = slideLength;
        isSliding = !isSliding;
        animator.SetBool("IsSliding", isSliding);
        slideDisableCollider.enabled = !slideDisableCollider.enabled;
    }

    
    private void HandleAttack() {
        if (Input.GetButtonDown("Fire1")) {
            attackTimer = timeBetweenAttacks;
            animator.SetTrigger("PlayerAttack");
            
            Collider2D hit = Physics2D.OverlapCircle(meleeHitCheck.position, meleeRadius, 1 << 10);

            if (hit != null) {
                EnemyHealth eh = hit.GetComponent<EnemyHealth>();
                if (eh != null) {
                    eh.TakeDamage(1);
                }
            }
        }
    }

    public void HandleDeath() {
        if (deathTime == initialDeathTime) {
            animator.SetTrigger("Die");
            move.x = 0;
            playerHealth.enabled = false;
        }

        deathTime--;
        if (deathTime <= 0) Respawn();
   
    }

    private void Respawn() {
        if (!respawnCalled) FindObjectOfType<GameSession>().DeleteLives(1);
        respawnCalled = true;
    }
}
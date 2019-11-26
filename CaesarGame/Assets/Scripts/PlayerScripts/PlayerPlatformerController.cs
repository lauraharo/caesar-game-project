using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7f;
    public float jumpTakeOffSpeed = 7f;
    public float slideSpeed = 5f;
    public float slideLength = 5f;

    [SerializeField] private Collider2D slideDisableCollider;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private float ceilingCheckRadius = 0.3f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool isSliding;
    private bool canStandUp;
    private float slideTime;
    private Vector2 move;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isSliding = false;
        slideDisableCollider.enabled = true;
    }

    protected override void ComputeVelocity()
    {

        
        if (isSliding) {
            HandleSliding();
        } else {
            HandleNormalMovement();
        }

 
        targetVelocity = isSliding ? move * slideSpeed : move * maxSpeed;
        canStandUp = !Physics2D.OverlapCircle(ceilingCheck.position, 0.4f, whatIsGround);

    }


    // All logic regarrding movement during a slide is here
    // TODO: Refactor the if structure
    private void HandleSliding() {
        if (canStandUp && slideTime <= 0) ToggleSlide();

        slideTime = slideTime <= 0 ? 0 : slideTime - 1;

        if (Input.GetButtonDown("Jump") && grounded && canStandUp) {
            ToggleSlide();
            HandleJump();
        }

        float slideDirection = Input.GetAxis("Horizontal");
        if (!canStandUp) {
            if (slideDirection > 0) spriteRenderer.flipX = false;
            else if (slideDirection < 0) spriteRenderer.flipX = true;
        }
        else if ((move.x > 0 && slideDirection < 0) || (move.x < 0 && slideDirection > 0)) {
            ToggleSlide();
        }

        if (spriteRenderer.flipX) {
            move.x = -0.5f;
        }
        else {
            move.x = 0.5f;
        }
 

    }

    // All "normal" movement logic when character is not sliding
    private void HandleNormalMovement() {
        move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        HandleJump();

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("VelocityY", velocity.y);

        // only flip if we are moving
        if (Mathf.Abs(move.x) > 0) {
            spriteRenderer.flipX = (move.x < -0.01f);
        }

        targetVelocity = move * maxSpeed;

    }

    private void ToggleSlide()
    {
        slideTime = slideLength;
        isSliding = !isSliding;
        animator.SetBool("IsSliding", isSliding);
        slideDisableCollider.enabled = !slideDisableCollider.enabled;
    }

    private void HandleJump()
    {
        
        if (Input.GetButtonDown("Jump") && grounded) {
            if (Input.GetKey(KeyCode.DownArrow)) {
                ToggleSlide();
            }
            else {
                velocity.y = jumpTakeOffSpeed;
            }
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }
    }
}
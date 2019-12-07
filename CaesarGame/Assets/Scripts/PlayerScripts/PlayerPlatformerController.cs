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
    [SerializeField] private Transform ceilingCheck, attackStart, attackEnd;
    [SerializeField] private float ceilingCheckRadius = 0.4f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool canStandUp;
    private bool isFacingRight;
    private bool isSliding;
    private float slideTime;
    private Vector2 move;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isSliding = false;
        slideDisableCollider.enabled = true;
        isFacingRight = true;
    }

    protected override void ComputeVelocity()
    {


        if (isSliding) HandleSlidingControls();
        else HandleControls();
        

        targetVelocity = isSliding ? move * slideSpeed : move * maxSpeed;
        canStandUp = !Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, whatIsGround);

    }


    // All logic regarrding movement during a slide is here
    // TODO: Refactor the if structure
    private void HandleSlidingControls() {
        if (canStandUp && slideTime <= 0) ToggleSlide();

        slideTime = slideTime <= 0 ? 0 : slideTime - 1;

        if (Input.GetButtonDown("Jump") && grounded && canStandUp) {
            ToggleSlide();
            HandleJumpAndSlide();
        }

        // read input: right or left keys positive values right, negative left
        float horizontalInput = Input.GetAxis("Horizontal");

        if (!isFacingRight) {
            move.x = -0.5f;
            if (horizontalInput > 0) ToggleSlide();
        }
        else {
            move.x = 0.5f;
            if (horizontalInput < 0) ToggleSlide();
        }
 

    }

    // All "normal" movement logic when character is not sliding
    private void HandleControls() {
        move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        HandleJumpAndSlide();
        HandleAttack();

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("VelocityY", velocity.y);

        // only flip if we are moving
        if (move.x > 0.01f && !isFacingRight) {
            Flip();
        }
        else if (move.x < -0.01f && isFacingRight) {
            Flip();
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
            if (Input.GetKey(KeyCode.DownArrow)) {
                ToggleSlide();
            }
            else {
                velocity.y = jumpTakeOffSpeed;
            }
        }
        else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > jumpTakeOffSpeed / 3) {
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
            animator.SetTrigger("PlayerAttack");
            
            RaycastHit2D hit = Physics2D.Linecast(attackStart.position, attackEnd.position, 1 << 8);

            // here we can add damage cause to enemy logic
            if (hit.collider != null) {
                Debug.Log("you punched wall");
            }

            Debug.DrawLine(attackStart.position, attackEnd.position, Color.green, 1f);

        }
    }
}
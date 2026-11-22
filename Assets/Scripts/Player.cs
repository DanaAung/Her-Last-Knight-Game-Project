using System;
using UnityEngine;


public class Player : Entity
{
    [Header("Movement details")]
    [SerializeField] protected float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8;

    [Space]
    [SerializeField] protected Audio_Manager Audio_Manager;

    private bool canJump = true;
    private bool isWalking = false;
    private float xInput;

    protected override void Update()
    {
        base.Update();
        HandleInput();
        HandleWalkingSound();
    }

    private void HandleWalkingSound()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (!isWalking)
            {
                isWalking = true;
                Audio_Manager.StartFootstepSound();
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                Audio_Manager.StopFootstepSound();
            }
        }
    }

    private void HandleInput()
    {
        if (Time.timeScale == 0)
            return;
        
        xInput = Input.GetAxisRaw("Horizontal");
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space))
            TryToJump();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            HandleAttack();
    }

    protected override void HandleMovement()
    {

        if (canMove)
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    private void TryToJump()
    {
        if (isGrounded && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (Audio_Manager != null)
                Audio_Manager.PlaySFX(Audio_Manager.jump);
        }
    }

    public override void EnableMovement(bool enable)
    {
        base.EnableMovement(enable);
        canJump = enable;
    }

    protected override void Die()
    {
        base.Die();
        UI.instance.EnableGameOverUI();
    }
}

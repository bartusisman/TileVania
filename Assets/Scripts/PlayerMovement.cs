using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator animator;
    CapsuleCollider2D myCapsuleCollider;
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    bool IsOnGround()
    {
        return myCapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void Update()
    {
        Run();
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        animator.SetBool("isJumping", !IsOnGround());
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && IsOnGround())
        {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
            animator.SetBool("isJumping", true);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void FlipSprite()
    {
        if (moveInput.x != 0)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x = Mathf.Abs(currentScale.x) * Mathf.Sign(moveInput.x);
            transform.localScale = currentScale;
        }
    }
    
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool isRunning = moveInput.x != 0;
        animator.SetBool("isRunning", isRunning);

        FlipSprite();
    }

}

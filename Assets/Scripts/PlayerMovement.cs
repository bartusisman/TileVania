using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    [SerializeField] float playerSpeed = 10f;

    int direction;

    Animator animator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        
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

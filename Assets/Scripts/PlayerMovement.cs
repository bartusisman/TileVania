using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    [SerializeField] float playerSpeed = 10f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Run();
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
        
        /*if (moveInput.x == -1 && moveInput.y == 0)
        {
            
        }

        else if (moveInput.x == 1 && moveInput.y == 0)
        {
            
        }
        */
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * playerSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }
}

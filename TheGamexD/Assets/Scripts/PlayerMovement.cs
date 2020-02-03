using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool isJumping = false;
    [SerializeField] private Rigidbody rigidbody;
    private Vector3 movement;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 0 && !isJumping)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
            Jump();
            }
        }
    }

    private void Jump()
    {
        isJumping = true;
        rigidbody.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void Move()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumping: MonoBehaviour
{
    public Vector3 moveDirection;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public float moveSpeed = 7.0f;
    public float Gravity = -12f;
    private float VelocityY;

    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2, 0.0f);
    }

    void OnCollisionStay()
    { 
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            float JumpVelocity = Mathf.Sqrt(-2 * Gravity * jumpForce);
            VelocityY = JumpVelocity;
            
            //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        Inputs();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Inputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, VelocityY, moveZ).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, VelocityY, moveDirection.z * moveSpeed);
    }
}

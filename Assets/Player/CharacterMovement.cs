using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight;
    public float gravityValue;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer == true)
        {
            playerVelocity.y = -1f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer == true)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
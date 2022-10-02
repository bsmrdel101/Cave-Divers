using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace BEAN 
{
    public class PlayerMovement : NetworkBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 12f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 3f;
        private Vector3 velocity;

        [Header("Ground Check")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;
        private bool isGrounded;

        [Header("References")]
        [SerializeField] private CharacterController controller;


        private void Update()
        {
            if (!IsOwner) return;
            HandlePlayerMovement();
        }

        private void HandlePlayerMovement()
        {
            isGrounded = CheckGround();
            if (isGrounded && velocity.y < 0) velocity.y = -2f;

            MovePlayer();
            HandlePlayerJump();

            // Apply gravity to player
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        private bool CheckGround()
        {
            return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        }

        private void MovePlayer()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * moveSpeed * Time.deltaTime);
        }
    
        private void HandlePlayerJump()
        {
            if (Input.GetButton("Jump") && isGrounded) 
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
    }
}

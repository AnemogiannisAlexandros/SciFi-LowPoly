using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Player Movement Script. EzPz
/// </summary>

[RequireComponent(typeof(PlayerAnimationmanager))]

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    private PlayerAnimationmanager animationManager;

    [SerializeField]
    private float movementSpeed = 1, sprintSpeed = 2,jumpForce = 8;

    private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;



    public Vector2 GetInput() 
    {
        return new Vector2(moveDirection.x, moveDirection.z);
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animationManager = GetComponent<PlayerAnimationmanager>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            Debug.Log("Grounded");
            moveDirection = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical")*transform.forward;
            if (!InputManager.Instance.GetInputMethod().SprintKey())
            {
                moveDirection *= movementSpeed;
            }
            else
            {
                moveDirection *= sprintSpeed;
            }
            if (InputManager.Instance.GetInputMethod().JumpKey())
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            Debug.Log("Not Grounded");

            moveDirection.y -= gravity * Time.deltaTime;

        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

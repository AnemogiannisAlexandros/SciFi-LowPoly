using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Player Movement Script.
/// Implementation is made with CharacterController For further manipulation
/// </summary>

[RequireComponent(typeof(PlayerAnimationmanager))]

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    private PlayerAnimationmanager animationManager;

    [SerializeField]
    private float movementSpeed = 3, sprintSpeed = 6, jumpHeight = 2, airSpeed = 1.5f;

    private Vector3 moveDirection = Vector3.zero;
    private float gravity;
    public Vector2 GetInput() 
    {
        return new Vector2(moveDirection.x, moveDirection.z);
    }
    void Start()
    {
        
        TryGetComponent<CharacterController>(out characterController);
        TryGetComponent<PlayerAnimationmanager>(out animationManager);
        gravity = Physics.gravity.y;
    }

    void Update()
    {
        float horizontal=0, vertical=0;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (characterController.isGrounded)
        {
            moveDirection = transform.right * horizontal + vertical * transform.forward;
            moveDirection.y = 0;

            if (!InputManager.Instance.GetInputMethod().SprintKey())
            {
                moveDirection *= movementSpeed;
            }
            else
            {
                moveDirection *= sprintSpeed;
            }
            Debug.Log("Grounded");
            if (InputManager.Instance.GetInputMethod().JumpKey())
            {
                Debug.Log("Jump");
                moveDirection.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
                animationManager.SetJump("Jump");
            }
        }
        else
        {
            moveDirection += (transform.right * horizontal * airSpeed + transform.forward * vertical * airSpeed + transform.up * gravity) * Time.deltaTime;
            Debug.Log("Not Grounded");
        }
        characterController.Move(moveDirection * Time.deltaTime);
        animationManager.SetMovement(new Vector2(horizontal, vertical));
    }
}

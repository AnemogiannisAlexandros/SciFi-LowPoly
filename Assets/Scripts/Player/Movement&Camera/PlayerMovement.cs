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

    public Vector2 GetInput() 
    {
        return new Vector2(moveDirection.x, moveDirection.z);
    }
    void Start()
    {
        
        TryGetComponent<CharacterController>(out characterController);
        TryGetComponent<PlayerAnimationmanager>(out animationManager);
    }

    void Update()
    {
        float horizontal=0, vertical=0;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (characterController.isGrounded)
        {
            moveDirection.y = 0;
            moveDirection = transform.right * horizontal + vertical * transform.forward;
            Debug.Log("Grounded");
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
                moveDirection.y += Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                animationManager.SetJump("Jump");
            }
        }
        else
        {
            moveDirection += (transform.right * horizontal * airSpeed + transform.forward * vertical * airSpeed + Physics.gravity.y * transform.up) * Time.deltaTime;
            //Debug.Log("Not Grounded");
        }
        characterController.Move(moveDirection * Time.deltaTime);
        animationManager.SetMovement(new Vector2(horizontal, vertical));
    }
}

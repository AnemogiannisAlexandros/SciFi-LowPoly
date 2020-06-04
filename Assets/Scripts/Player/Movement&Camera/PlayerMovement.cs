using System.Collections;
using System.Collections.Generic;
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
    private float movementSpeed=1,sprintSpeed=2;

    float horizontal, vertical;
    public Vector2 GetInput() 
    {
        return new Vector2(horizontal, vertical);
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animationManager = GetComponent<PlayerAnimationmanager>();
    }

    void Update()
    {
        if (!InputManager.Instance.GetInputMethod().SprintKey())
        {
            MoveCharacter(movementSpeed);
        }
        else 
        {
            MoveCharacter(sprintSpeed);
        }
    }
    void MoveCharacter(float speed)
    {
        horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        characterController.Move(transform.forward * vertical + transform.right * horizontal);
        animationManager.SetMovement(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }
}

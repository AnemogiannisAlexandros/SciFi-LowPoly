using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// Require A Way To Draw and Change the Necessary Values Depending On player input.
/// </summary>
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimationmanager : MonoBehaviour
{
    //Animator component attached to the player
    private Animator animator;


    void Start()
    {
        TryGetComponent<Animator>(out animator);
    }

    public void SetJump(string jump) 
    {
        animator.Play(jump,-1,0);
    }

    public void SetMovement(Vector2 axesinput) 
    {
        int multiplier = 0;

        bool isMoving;
        isMoving = axesinput == Vector2.zero ? false : true;

        animator.SetBool("isMoving",isMoving);

        if (InputManager.Instance.GetInputMethod().SprintKey())
        {
            multiplier = 2;
        }
        else 
        {
            multiplier = 1;
        }
        animator.SetFloat("VerticalInput", axesinput.y * multiplier);
        animator.SetFloat("HorizontalInput", axesinput.x * multiplier);
    }
}

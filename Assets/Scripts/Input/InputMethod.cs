using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base Class for all Input Methods.
/// Contains all keys we will need in the game
/// and assigns default Keyboard/Mouse input.
/// </summary>
public class InputMethod : ScriptableObject,IInput
{
    [SerializeField]
    private KeyCode crouchKey = KeyCode.LeftControl,
        fireKey = KeyCode.Mouse0,
        interactKey = KeyCode.E,
        jumpKey = KeyCode.Space,
        pauseKey = KeyCode.Escape,
        sprintKey = KeyCode.LeftShift;

    public bool CrouchKey()
    {
        return Input.GetKey(crouchKey); 
    }

    public bool FireKey()
    {
        return Input.GetKey(fireKey);
    }

    public bool InteractKey()
    {
        return Input.GetKeyDown(interactKey);
    }

    public bool JumpKey()
    {
        return Input.GetKeyDown(jumpKey);
    }

    public bool PauseKey()
    {
        return Input.GetKeyDown(pauseKey);
    }

    public bool SprintKey()
    {
        return Input.GetKey(sprintKey);
    }
}

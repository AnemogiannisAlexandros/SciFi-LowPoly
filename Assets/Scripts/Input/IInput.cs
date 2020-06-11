using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Input Interface with bool functions
/// </summary>
public interface IInput
{
    bool FireKey();
    bool InteractKey();
    bool JumpKey();
    bool CrouchKey();
    bool PauseKey();
    bool SprintKey();
}

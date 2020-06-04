using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    bool FireKey();
    bool InteractKey();
    bool JumpKey();
    bool CrouchKey();
    bool PauseKey();
    bool SprintKey();
}

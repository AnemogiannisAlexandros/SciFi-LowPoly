using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{
    //Interface of all interactable Objects
    public interface IInteractable
    {
        bool AllowInput();
        void StartInteraction();
        void UpdateInteraction();
        void CancelInteraction();
        bool SelfCanceled();
    }
}

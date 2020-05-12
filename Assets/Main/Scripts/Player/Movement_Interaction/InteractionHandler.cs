using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{
    /// <summary>
    /// All Interactions are being handled by this script
    /// depending on the type of the Item we deal with we use 
    /// the appropriate interaction method
    /// </summary>
    public class InteractionHandler : MonoBehaviour
    {

        //The interactable object we are interacting with at a given time
        private IInteractable currentInteractable;
        //Allow input during Interaction. Or Not
        bool AllowInput = true;

        public IInteractable GetInteractable()
        {
            return currentInteractable;
        }
        public void SetInteractable(IInteractable interactable)
        {
            currentInteractable = interactable;
        }

        private void Start()
        {
            currentInteractable = null;
        }
        private void Update()
        {
            if (PlayerManager.Instance.GetState() == PlayerState.Interacting)
            {
                HandleInteraction();
                if (Input.GetKeyDown(KeyCode.C) && AllowInput)
                {
                    CancelInteraction();
                }
            }
        }

        //Reset all appropriate values and start interaction depending the interactable.
        public void StartInteraction(IInteractable interactable)
        {
            currentInteractable = interactable;
            PlayerManager.Instance.SetState(PlayerState.Interacting);
            currentInteractable.StartInteraction();
        }

        //Update State of our interaction!!!
        public void HandleInteraction()
        {
            currentInteractable.UpdateInteraction();
            AllowInput = currentInteractable.AllowInput();
        }
        //Takes place when the player has decided to stop interaction with the object
        public void CancelInteraction()
        {
            currentInteractable.CancelInteraction();
            if (currentInteractable.SelfCanceled())
            {
                return;
            }
            currentInteractable = null;
            PlayerManager.Instance.SetState(PlayerState.Gameplay);
        }
    }
}

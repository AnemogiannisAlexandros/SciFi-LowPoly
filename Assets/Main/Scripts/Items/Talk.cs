using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{
    public class Talk : MonoBehaviour, IInteractable
    {
        public bool AllowInput()
        {
            return true;
        }

        public void CancelInteraction()
        {
            Debug.Log("End Dialogue");
        }

        public bool SelfCanceled()
        {
            return false;
        }

        public void StartInteraction()
        {
            Debug.Log("Initiate Dialogue");
        }

        public void UpdateInteraction()
        {
            Debug.Log("Dialogue Logic Here");
        }

    }
}

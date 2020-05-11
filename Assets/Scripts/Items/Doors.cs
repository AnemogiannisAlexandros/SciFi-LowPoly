using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{

    public class Doors : MonoBehaviour, IInteractable
    {
        public bool AllowInput()
        {
            return true;
        }

        public void CancelInteraction()
        {
        }

        public bool SelfCanceled()
        {
            throw new System.NotImplementedException();
        }

        public void StartInteraction()
        {
            transform.position += transform.up;
        }

        public void UpdateInteraction()
        {
        }
    }
}
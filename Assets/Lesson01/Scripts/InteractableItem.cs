using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson01
{
    public class InteractableItem : MonoBehaviour, IInteractable
    {
        public int health = 100;
        void IInteractable.Interact()
        {
            Debug.Log("Interacting with : " + gameObject.name + "with health" + health);
        }
    }
}

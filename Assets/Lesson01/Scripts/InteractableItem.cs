using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public class InteractableItem : MonoBehaviour, IInteractable, IDamagable
    {

        #region IInteractable
        void IInteractable.Interact()
        {
            Debug.Log("Interacting with : " + gameObject.name + "with health" + Health);
        }
        #endregion

        #region IDamagable
        public int Health { get; private set; }
        public void TakeDamage()
        {
            Health -= Random.Range(10, 90);
        }
        #endregion

        #region Unity Methods
        public void Start()
        {
            Health = 100;
        }
        #endregion
    }
}

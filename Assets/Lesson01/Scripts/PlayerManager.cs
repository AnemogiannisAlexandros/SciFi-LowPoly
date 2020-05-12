using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{ 
    public class PlayerManager : MonoBehaviour
    {
       
        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.GetState() != GameState.Pause)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    foreach (InteractableItem c in FindObjectsOfType<InteractableItem>())
                    {
                        c.GetComponent<IDamagable>().TakeDamage();
                        c.GetComponent<IInteractable>().Interact();
                    }
                }
            }
        }
    }
}

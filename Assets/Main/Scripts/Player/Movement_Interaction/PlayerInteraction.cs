using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Responsible for Interacting with objects in the Scene
/// </summary>

namespace main
{
    public class PlayerInteraction : MonoBehaviour
    {
        //The RayCast Distance of interaction
        [SerializeField]
        private float interactionDistance = 2;
        private RaycastHit hit;
        //The Handler of the interaction
        private InteractionHandler interactionHandler;
        //The interactable we found
        IInteractable interactable;

        void Start()
        {
            interactionHandler = GetComponent<InteractionHandler>();
        }

        void Update()
        {
            Debug.Log(interactable);
        }
        private void FixedUpdate()
        {
            switch (PlayerManager.Instance.GetState())
            {
                case PlayerState.Gameplay:
                    {
                        if (Physics.Raycast(transform.position, transform.forward, out hit))
                        {
                            if (hit.distance < interactionDistance && Input.GetKeyDown(KeyCode.E))
                            {
                                if (hit.collider.GetComponent<IInteractable>() != null)
                                {
                                    interactionHandler.StartInteraction(hit.collider.GetComponent<IInteractable>());
                                };
                            }
                        }
                        break;
                    }
            }
        }
    }
}

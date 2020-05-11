using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson01
{
    public class PlayerManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (InteractableItem c in FindObjectsOfType<InteractableItem>())
                {
                    c.GetComponent<IInteractable>().Interact();
                }
            }
        }
    }
}

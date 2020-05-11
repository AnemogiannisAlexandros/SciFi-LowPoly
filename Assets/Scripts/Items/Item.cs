using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main
{
    /// <summary>
    /// Base Class of all our Items
    /// </summary>

    [System.Serializable]
    public abstract class Item : MonoBehaviour, IInteractable
    {
        [SerializeField]
        protected Vector3 desiredRotation;
        [SerializeField]
        protected bool isPickable;
        [SerializeField]
        protected string itemName;
        [SerializeField]
        private bool HasSecret;
        //The position the object must be at when the lerp finishes
        private Vector3 endPosition;
        //The object's position at first interaction
        private Vector3 objectOriginalPosition;
        //The object's rotation at first interaction
        private Quaternion objectOriginalRotation;
        //smoothDamp necesity
        private Vector3 velocity;

        //The travel time of the object atinteractoin
        [SerializeField]
        private float smoothTravelTime = .35f;
        //The forward offset the object will be placed in comparison to the camera
        [SerializeField]
        private float forwardOffset = 0.3f;
        //The smoothRotation value of the Slerp Rotation
        [SerializeField]
        private float smoothRotation = 5f;
        //Allow input during Interaction. Or Not
        private bool AllowInput = true;
        //The valuse we need to rotate our object in all axis during interaction
        private float xMouse = 0, yMouse = 0;
        //The mouse sensitivity on inspection
        [SerializeField]
        private float sensitivity = 1;
        //The Slerp jurney Fraction.
        private float jurneyFrac = 0;

        private InteractionHandler interaction;

        void Awake()
        {
            interaction = FindObjectOfType<InteractionHandler>();
        }
        public string GetItemName()
        {
            return itemName;
        }
        public void SetItemName(string itemName)
        {
            this.itemName = itemName;
        }
        public Vector3 DesiredRotation()
        {
            return desiredRotation;
        }
        public void DefaultItemInteraction()
        {
            StartInteraction();
        }
        public virtual void StartInteraction()
        {
            jurneyFrac = 0;
            //Invoke the OnItemPickUp Event
            EventManager.Instance.OnItemPickUp.Invoke();
            //Set the end position of our interactable Object
            endPosition = interaction.transform.position + interaction.transform.forward * forwardOffset;
            //store the original position and rotation of our interactable object
            objectOriginalPosition = gameObject.transform.position;
            objectOriginalRotation = gameObject.transform.rotation;
            //Set the xMouse and yMouse starting values as per interactable instructed
            xMouse = desiredRotation.x;
            yMouse = desiredRotation.y;
            StartCoroutine(LerpItemToPlayer());
        }

        public virtual void UpdateInteraction()
        {
            if (AllowInput)
            {
                yMouse += Input.GetAxis("Mouse X") * sensitivity;
                xMouse += Input.GetAxis("Mouse Y") * sensitivity;
                Quaternion target = Quaternion.Euler(xMouse, yMouse, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothRotation);
                //If our inspectable object Hides a Secret We send another raycast to find it
                if (HasSecret)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(interaction.transform.position, interaction.transform.forward, out hit))
                    {
                        Debug.Log("We Running Now!!!");
                        Debug.DrawRay(interaction.transform.position, interaction.transform.forward);
                        if (hit.collider.CompareTag("Secret"))
                        {
                            //Invoke the SecretFound Event
                            EventManager.Instance.OnSecretFound.Invoke();
                            //No Logner a Secret
                            HasSecret = false;
                            //Detach any parent objects
                            hit.collider.transform.parent = null;
                            //Set our current interactable 
                            interaction.SetInteractable(hit.collider.GetComponent<IInteractable>());
                            //Start lerping the original object to 
                            StartCoroutine(LerpItemToOriginalWithSecret(interaction.GetInteractable()));
                        }
                    }
                }
            }
        }

        public virtual void CancelInteraction()
        {
            StartCoroutine(LerpItemToOriginal());
        }
        //Dissalow input while the coroutine is running.
        // Translate and Roate the object to appropriate positions
        // and adjust depth of field accordingly
        IEnumerator LerpItemToPlayer()
        {
            AllowInput = false;
            while (Vector3.Distance(transform.position, endPosition) >= 0.001f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, smoothTravelTime);
                Quaternion target = Quaternion.Euler(xMouse, yMouse, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothRotation);
                yield return new WaitForEndOfFrame();
            }
            AllowInput = true;
        }

        //Disallow input while the object travels back
        //Translate and Rotate the object 
        IEnumerator LerpItemToOriginal()
        {
            AllowInput = false;
            if (!isPickable)
            {
                while (Vector3.Distance(transform.position, objectOriginalPosition) >= 0.001f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, objectOriginalRotation, jurneyFrac);
                    transform.position = Vector3.SmoothDamp(transform.position, objectOriginalPosition, ref velocity, smoothTravelTime);
                    jurneyFrac += 0.009f;
                    yield return new WaitForEndOfFrame();
                }
            }
            else
            {
                gameObject.SetActive(false);
            }
            EventManager.Instance.OnItemPutDown.Invoke();
            PlayerManager.Instance.SetState(PlayerState.Gameplay);
            interaction.SetInteractable(null);
            AllowInput = true;
        }
        //Lerp original object to the appropriate position
        //and start interacting with the secret you just found!!!
        IEnumerator LerpItemToOriginalWithSecret(IInteractable secret)
        {
            AllowInput = false;
            while (Vector3.Distance(gameObject.transform.position, objectOriginalPosition) >= 0.001f)
            {
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, objectOriginalRotation, jurneyFrac);
                gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, objectOriginalPosition, ref velocity, smoothTravelTime);
                jurneyFrac += 0.009f;
                yield return new WaitForEndOfFrame();
            }
            secret.StartInteraction();
            AllowInput = true;
        }

        bool IInteractable.AllowInput()
        {
            return AllowInput;
        }

        public bool SelfCanceled()
        {
            return true;
        }
    }
}

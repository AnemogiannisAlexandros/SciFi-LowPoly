using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace main
{
    public class CameraMouse : MonoBehaviour
    {
        //MouseCurrentLookingPosition
        Vector2 mouseLook;
        //Camera Smoothing
        Vector2 smoothV;

        //Is The player Focusing?
        [SerializeField]
        private bool isFocusing = false;
        //Mouse Sensitivity
        [SerializeField]
        private float sensitivity = 1, smoothing = 5;
        //The speed at which we zoom in and out of focus
        [SerializeField]
        [Range(0, 1)]
        private float lerpSpeed = 0.23f;
        //The HeadBob Up and Down Streangth value
        [SerializeField]
        private float headBobStrength = .5f;
        //How Frequent the headbob Happens
        [SerializeField]
        private float headBobFrequency = 2;

        //SmoothDamp necessity
        private float focusVelocity = 0;
        private float curVelocity = 0;
        //PlayerMovement Reference
        private PlayerMovement playerMovement;

        GameObject character;
        //starting height of our cam for the head bob to bounce between
        private float camStartHeight;
        //0 to 1 fraction of head bob completition
        float curHeadBobFraction;
        // Start is called before the first frame update
        void Start()
        {
            character = this.transform.parent.gameObject;
            //Cursor.lockState = CursorLockMode.Locked;
            playerMovement = GetComponentInParent<PlayerMovement>();
            camStartHeight = transform.localPosition.y;
            curHeadBobFraction = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            //Check if focusing and adjust FOV
            isFocusing = Input.GetKey(KeyCode.Mouse1) ? true : false;
            if (isFocusing)
            {
                Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, 40, ref focusVelocity, lerpSpeed);
            }
            else
            {
                Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, 60, ref focusVelocity, lerpSpeed);
            }
            //If we are not in a Gameplay state don't do anything else
            if (PlayerManager.Instance.GetState() != PlayerState.Gameplay)
                return;

            //Mouse and HeadBob Conditions
            Vector2 mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDir = Vector2.Scale(mouseDir, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, mouseDir.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, mouseDir.y, 1f / smoothing);
            mouseLook += smoothV;
            mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


            if (playerMovement.GetInput() != Vector2.zero)
            {
                curHeadBobFraction = Mathf.PingPong(Time.time * headBobFrequency, headBobStrength);
                if (curHeadBobFraction < headBobStrength / 2)
                {
                    transform.position -= new Vector3(0, headBobStrength * Time.deltaTime * 0.5f, 0);
                }
                else
                {
                    transform.position += new Vector3(0, headBobStrength * Time.deltaTime * 0.5f, 0);
                }
            }
            else
            {
                float tempFloat = Mathf.SmoothDamp(transform.localPosition.y, camStartHeight, ref curVelocity, 0.1f);

                transform.localPosition = new Vector3(0, tempFloat, 0);
            }

        }
    }
}


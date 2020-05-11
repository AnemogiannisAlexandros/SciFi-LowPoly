using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Movement Script. EzPz
/// </summary>
namespace main
{
    public class PlayerMovement : MonoBehaviour
    {

        private CharacterController characterController;

        [SerializeField]
        private float movementSpeed = 1;

        float horizontal, vertical, down;
        public Vector2 GetInput()
        {
            return new Vector2(horizontal, vertical);
        }
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (PlayerManager.Instance.GetState() != PlayerState.Gameplay)
                return;
            horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
            vertical = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
            down = -9.81f;
            characterController.Move(transform.forward * vertical + transform.right * horizontal + transform.up * down);
        }
    }
}

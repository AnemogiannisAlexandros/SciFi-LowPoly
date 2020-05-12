using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General Manager of the player and his current State
/// </summary>
namespace main
{
    //Enum For the current player state
    public enum PlayerState
    {
        Gameplay,
        Interacting
    }

    public class PlayerManager : MonoBehaviour
    {
        //singleton
        private static PlayerManager m_instance;
        public static PlayerManager Instance { get { return m_instance; } }

        //The player's current state
        private PlayerState playerState;
        //Inventory of the player
        private Inventory playerInventory;

        public void LoadInventory(Inventory lastKnownInventory)
        {

        }
        public Inventory GetInventory()
        {
            return playerInventory;
        }
        public PlayerState GetState()
        {
            return playerState;
        }
        public void SetState(PlayerState playerState)
        {
            this.playerState = playerState;
        }

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {
            playerInventory = ScriptableObject.CreateInstance<Inventory>();

            playerState = PlayerState.Gameplay;
        }

        // Update is called once per frame
        void Update()
        {
            foreach (Item it in playerInventory.inventoryItems)
            {
                Debug.Log(it.GetItemName());
            }
        }
        private void OnDisable()
        {

        }
    }

}
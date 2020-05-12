using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace main
{
    /// <summary>
    /// Makes Events available for Listeners!
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        private static EventManager m_instance;
        public static EventManager Instance { get { return m_instance; } }

        [Tooltip("Runs when an item is added into the Inventory")]
        public UnityEvent OnItemAddedToInventory;
        [Tooltip("Runs when another item is found as part of an inspected item")]
        public UnityEvent OnSecretFound;
        [Tooltip("Runs when a new Sequence has started")]
        public UnityEvent OnSequenceStarted;
        [Tooltip("Runs when an item has been picked up for interaction")]
        public UnityEvent OnItemPickUp;
        [Tooltip("Runs when an item has been put down from interaction")]
        public UnityEvent OnItemPutDown;

        //Singleton
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
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

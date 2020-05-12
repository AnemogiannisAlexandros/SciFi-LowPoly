using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public enum GameState
    {
        Gameplay,
        Pause
    }
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_instance;
        public static GameManager Instance { get { return m_instance; } private set { } }
        private GameState currentState;
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
        }

        private void Start()
        {
            currentState = GameState.Gameplay;
        }
        public void SetState(GameState state)
        {
            currentState = state;
        }
        public GameState GetState()
        {
            return currentState;
        }
    }
}

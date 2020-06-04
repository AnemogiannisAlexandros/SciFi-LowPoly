using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GamePlay,
    Interacting,
    Pause
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GameState CurrentState { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            CurrentState = GameState.GamePlay;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

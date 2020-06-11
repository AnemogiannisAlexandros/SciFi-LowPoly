using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Available states
/// </summary>
public enum GameState
{
    GamePlay,
    Interacting,
    Pause
}
/// <summary>
/// Holds the game's current state
/// and allows for state changes.
/// </summary>
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    ///Get and set a state through this Property 
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

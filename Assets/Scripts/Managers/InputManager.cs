using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Requires an InputMethod Scriptable Object
/// with assigned Buttons to allow for different Input devices.
/// </summary>
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField]
    private InputMethod inputMethod = null;

    public InputMethod GetInputMethod() 
    {
        return inputMethod;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
}

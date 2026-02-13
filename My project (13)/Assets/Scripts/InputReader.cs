using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3> MouseClicked;

    public void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            MouseClicked?.Invoke(Mouse.current.position.ReadValue());
    }
}
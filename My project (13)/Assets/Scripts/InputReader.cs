using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3> MouseClicked;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MouseClicked?.Invoke(Input.mousePosition);
    }
}
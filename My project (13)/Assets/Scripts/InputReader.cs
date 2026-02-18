using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    int deviceButtonNumber = 0;

    public event Action<Vector3> MouseClicked;

    public void Update()
    {
        if (Input.GetMouseButtonDown(deviceButtonNumber))
            MouseClicked?.Invoke(Input.mousePosition);
    }
}
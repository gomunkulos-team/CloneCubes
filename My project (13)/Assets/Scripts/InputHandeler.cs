using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandeler : MonoBehaviour
{
    private float _maxDistance = 500;

    public event Action<BoomCube> CubeSelected;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _maxDistance))
            {
                if (hit.collider.TryGetComponent<BoomCube>(out BoomCube cube))
                {
                    CubeSelected?.Invoke(cube);
                }
            }
        }
    }
}

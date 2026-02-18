using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private float _maxDistance = 500;

    public event Action<BoomCube> CubeSelected;

    private void OnEnable()
    {
        _inputReader.MouseClicked += Raycast;
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= Raycast;
    }

    private void Raycast(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance))
        {
            if (hit.collider.TryGetComponent(out BoomCube cube))
            {
                CubeSelected?.Invoke(cube);
            }
        }
    }
}

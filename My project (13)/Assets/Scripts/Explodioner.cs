using System.Collections.Generic;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    [SerializeField] private CubeFabric _cubeFabric;
    [SerializeField] private float _exlosionForce = 10f;

    private float _exposionRadius = 0.5f;

    private void OnEnable()
    {
        _cubeFabric.CubeListsChanged += Explode;
    }

    private void OnDisable()
    {
        _cubeFabric.CubeListsChanged -= Explode;
    }

    private void Explode(List<Rigidbody> rigidbodies, Vector3 position)
    {
        foreach (Rigidbody body in rigidbodies)
        {
            body.AddExplosionForce(_exlosionForce, position, _exposionRadius, 0, ForceMode.Force);
        }
    }
}
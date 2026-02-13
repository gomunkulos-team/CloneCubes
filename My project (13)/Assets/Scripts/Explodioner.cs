using System.Collections.Generic;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    [SerializeField] private float _exlosionForce = 10f;
    [SerializeField] private CubeSpawner _cubeSpawner;

    private float _exposionRadius = 1f;

    private void OnEnable()
    {
        _cubeSpawner.CubeListsChanged += Explode;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeListsChanged -= Explode;
    }

    private void Explode(List<Rigidbody> cubeList, Vector3 position)
    {
        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(_exlosionForce, position, _exposionRadius, 0, ForceMode.Force);
        }
    }
}
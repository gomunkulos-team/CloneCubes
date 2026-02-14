using System.Collections.Generic;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    [SerializeField] private float _exlosionForce = 10f;

    private float _exposionRadius = 1f;

    public void Explode(List<Rigidbody> cubeList, Vector3 position)
    {
        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(_exlosionForce, position, _exposionRadius, 0, ForceMode.Force);
        }
    }
}
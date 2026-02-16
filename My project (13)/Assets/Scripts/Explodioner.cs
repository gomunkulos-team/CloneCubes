using System.Collections.Generic;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    private float _baseExlosionForce = 10f;

    private float _baseExplosionRadius = 2f;

    public void Explode(List<Rigidbody> cubeList, Vector3 position)
    {
        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(_baseExlosionForce, position, _baseExplosionRadius, 0, ForceMode.Force);
        }
    }

    public void Explode(List<Rigidbody> cubeList, Vector3 position,  float exlosionForce)
    {
        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(exlosionForce, position, _baseExplosionRadius, 0, ForceMode.Impulse);
        }
    }
}
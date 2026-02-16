using System.Collections.Generic;
using UnityEngine;

public class Explodioner : MonoBehaviour
{
    private float _baseExlosionForce = 10f;
    private float _explosionForceMultiplier = 2f;
    private float _baseExplosionRadius = 5f;
    private float _explodionRadiusMultiplier = 2f;

    public void Explode(List<Rigidbody> cubeList, Vector3 position)
    {
        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(_baseExlosionForce, position, _baseExplosionRadius, 0, ForceMode.Force);
        }
    }

    public void Explode(BoomCube cube)
    {
        List<Rigidbody> cubeList = new List<Rigidbody>();
        float explosionForse = (_baseExlosionForce * _explosionForceMultiplier) / cube.transform.localScale.x;
        float exploisionRadius = (_baseExplosionRadius * _explodionRadiusMultiplier) / cube.transform.localScale.y;

        cubeList = GetRigidbodies(cube, exploisionRadius);

        foreach (Rigidbody body in cubeList)
        {
            body.AddExplosionForce(explosionForse, cube.transform.position, exploisionRadius, 0, ForceMode.Impulse);
        }
    }

    private List<Rigidbody> GetRigidbodies(BoomCube cube, float exploisionRadius)
    {
        List<Rigidbody> cubesRigidbodyList = new List<Rigidbody>();

        Collider[] cubeColliders = Physics.OverlapSphere(cube.transform.position, exploisionRadius);

        foreach (Collider collider in cubeColliders)
        {
            if (collider.attachedRigidbody != null)
                cubesRigidbodyList.Add(collider.attachedRigidbody);
        }

        return cubesRigidbodyList;
    }
}
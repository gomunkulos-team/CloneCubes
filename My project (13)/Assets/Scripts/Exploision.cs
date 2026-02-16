using System.Collections.Generic;
using UnityEngine;

public class Exploision : MonoBehaviour
{
    float _baseExploisionRadius = 500;
    float _explodionRadiusMultiplier = 1.5f;

    public List<Rigidbody> GetRigidbodies(BoomCube cube)
    {
        float exploisionRadius = (_baseExploisionRadius * _explodionRadiusMultiplier) / cube.transform.localScale.y;

        List<Rigidbody> cubesRigidbodyList = new List<Rigidbody>();

        Collider[] cubeColliders = Physics.OverlapSphere(cube.transform.position, exploisionRadius);

        foreach (Collider collider in cubeColliders)
        {
            collider.TryGetComponent(out Rigidbody cubeRigidbody);
            cubesRigidbodyList.Add(cubeRigidbody);
        }

        return cubesRigidbodyList;
    }
}

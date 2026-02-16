using System.Collections.Generic;
using UnityEngine;

public class Exploision : MonoBehaviour
{
    float _baseExploisionRadius = 5;
    float _explodionRadiusMultiplier = 2f;

    public List<Rigidbody> GetRigidbodies(BoomCube cube)
    {
        float exploisionRadius = (_baseExploisionRadius * _explodionRadiusMultiplier) / cube.transform.localScale.y;

        List<Rigidbody> cubesRigidbodyList = new List<Rigidbody>();

        Collider[] cubeColliders = Physics.OverlapSphere(cube.transform.position, exploisionRadius);

        foreach (Collider collider in cubeColliders)
        {
            if(collider.attachedRigidbody != null)
                cubesRigidbodyList.Add(collider.attachedRigidbody);
        }

        return cubesRigidbodyList;
    }
}

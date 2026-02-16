using System;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explodioner _explodioner;
    [SerializeField] private Exploision _exploision;

    private float _basicExplosionForce = 5f;

    public event Action<BoomCube> CubeExploded;

    private void OnEnable()
    {
        _raycaster.CubeSelected += TryToCopyCube;
    }

    private void OnDisable()
    {
        _raycaster.CubeSelected -= TryToCopyCube;
    }

    private void TryToCopyCube(BoomCube cube)
    {
        List<BoomCube> cubesList = new List<BoomCube>();
        List<Rigidbody> rigidbodyList = new List<Rigidbody>();

        if (cube.ChanceToCopy >= UnityEngine.Random.value)
        {
            cubesList = _cubeSpawner.SpawnCubes(cube);

            foreach (BoomCube buferCube in cubesList)
            {
                buferCube.TryGetComponent(out Rigidbody buferCubeRigidbody);
                rigidbodyList.Add(buferCubeRigidbody);
            }

            _explodioner.Explode(rigidbodyList, cube.transform.position);
        }
        else
        {
            float explosionRadius = (200 * 1.5f) / cube.transform.localScale.y;
            float exploisionForseMultiplier = 2;
            float explodionForse = (_basicExplosionForce * exploisionForseMultiplier) / cube.transform.localScale.x;

            rigidbodyList = _exploision.GetRigidbodies(cube);
            _explodioner.Explode(rigidbodyList, cube.transform.position, explosionRadius, explodionForse);
        }

        Destroy(cube.gameObject);
    }
}
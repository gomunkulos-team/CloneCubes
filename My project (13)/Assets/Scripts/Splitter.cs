using System;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explodioner _explodioner;
    [SerializeField] private Exploision _exploision;
    [SerializeField] private float _basicExplosionForce = 10f;

    private float _explosionForceMultiplier = 2f;

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
            float explodionForse = (_basicExplosionForce * _explosionForceMultiplier) / cube.transform.localScale.x;

            rigidbodyList = _exploision.GetRigidbodies(cube);
            _explodioner.Explode(rigidbodyList, cube.transform.position, explodionForse);
        }

        Destroy(cube.gameObject);
    }
}
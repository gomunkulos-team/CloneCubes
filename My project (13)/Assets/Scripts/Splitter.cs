using System;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explodioner _explodioner;

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
        if (cube.ChanceToCopy >= UnityEngine.Random.value)
        {
            List<BoomCube> cubesList = new List<BoomCube>();
            List<Rigidbody> rigidbodyList = new List<Rigidbody>();

            cubesList = _cubeSpawner.SpawnRandomNumberOfCubes(cube);

            foreach (BoomCube buferCube in cubesList)
            {
                if (buferCube.TryGetComponent(out Rigidbody buferCubeRigidbody))
                    rigidbodyList.Add(buferCubeRigidbody);
            }

            _explodioner.Explode(rigidbodyList, cube.transform.position);
        }
        else
        {
            _explodioner.Explode(cube);
        }

        _cubeSpawner.DestroyCube(cube);
    }
}
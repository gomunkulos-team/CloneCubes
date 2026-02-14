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
            _explodioner.Explode( _cubeSpawner.CopyCubes(cube), cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private int _minCubQuantity = 2;
    private int _maxCubQuantity = 6;
    private float _scaleMultiplier = 0.5f;
    private float _copyChanceMultiplier = 2;

    public List<BoomCube> SpawnRandomNumberOfCubes(BoomCube boomCube)
    {
        List<BoomCube> cubeRigidbodyList = new List<BoomCube>();

        int numberOfCubes = UnityEngine.Random.Range(_minCubQuantity, _maxCubQuantity);

        for (int i = 0; i < numberOfCubes; i++)
        {
            BoomCube copyCube = Instantiate(boomCube);
            copyCube.transform.localScale *= _scaleMultiplier;
            copyCube.Renderer.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f);
            copyCube.DecreaseCahceToCopy(_copyChanceMultiplier);

            cubeRigidbodyList.Add(copyCube);
        }

        return cubeRigidbodyList;
    }

    public void DestroyCube (BoomCube cube)
    {
        Destroy(cube.gameObject);
    }
}
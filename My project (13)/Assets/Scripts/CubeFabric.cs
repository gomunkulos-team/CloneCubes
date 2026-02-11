using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeFabric : MonoBehaviour
{
    [SerializeField] private InputHandeler _inputHandeler;

    public event Action<List<Rigidbody>, Vector3> CubeListsChanged;

    private int _minCubQuantity = 2;
    private int _maxCubQuantity = 6;
    private float _scaleIndex = 0.5f;
    private float _copyChanceIndex = 2;

    private List<Rigidbody> _cubeList = new List<Rigidbody>();

    private void OnEnable()
    {
        _inputHandeler.CubeSelected += Copy;
    }

    private void OnDisable()
    {
        _inputHandeler.CubeSelected -= Copy;
    }

    private void Copy(BoomCube boomCube)
    {
        int numberOfCubes = UnityEngine.Random.Range(_minCubQuantity, _maxCubQuantity);

        _cubeList.Clear();

        if (boomCube.ChanceToCopy >= UnityEngine.Random.value)
        {
            for (int i = 0; i < numberOfCubes; i++)
            {
                BoomCube copyCube = Instantiate(boomCube);
                copyCube.transform.localScale *= _scaleIndex;
                copyCube.Renderer.material.color = UnityEngine.Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f);
                copyCube.DecreaseCahceToCopy(_copyChanceIndex);

                Rigidbody rig = copyCube.GetComponent<Rigidbody>();

                _cubeList.Add(rig);
            }

            CubeListsChanged?.Invoke(_cubeList, boomCube.transform.position);
        }

        Destroy(boomCube.gameObject);
    }
}

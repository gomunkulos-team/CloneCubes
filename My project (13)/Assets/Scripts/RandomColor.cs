using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV(0f, 1f, 0.7f, 1f, 0.7f, 1f);
    }
}

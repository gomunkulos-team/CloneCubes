using UnityEngine;


public class BoomCube : MonoBehaviour
{
    private float _chanceToCopy = 1;

    public Renderer Renderer {  get; private set; }
    public float ChanceToCopy { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        ChanceToCopy = _chanceToCopy;
    }

    public void DecreaseCahceToCopy(float multiplier)
    {
        ChanceToCopy /= multiplier;
    }
}
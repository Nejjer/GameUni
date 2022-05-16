using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPole : MonoBehaviour
{
    [SerializeField] private bool active;
    [SerializeField][Range(0,5)] private float maxIntensity;
    private Generator _generator;

    public bool Active
    {
        get => active;
        set
        {
            active = value;
            _light.enabled = active;
        }
    }

    private Light2D _light;
    private void Start()
    {
        _light = GetComponent<Light2D>();
        _generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();
        Active = active;
    }

    private void Update()
    {
        _light.intensity = _generator.MathIntensity(maxIntensity);
    }
}
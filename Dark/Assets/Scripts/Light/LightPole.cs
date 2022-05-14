using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPole : MonoBehaviour
{
    [SerializeField] private bool active;

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
        Active = active;
    }
}
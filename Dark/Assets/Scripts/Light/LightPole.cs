using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPole : MonoBehaviour
{
    [SerializeField] private bool active;
    [SerializeField][Range(0,5)] private float maxIntensity;
    [SerializeField] [Range(0, 1)] private float chanceUnstableLight = 0.3f;
    private Generator _generator;
    private float _deltaIntensity;
    // Setup light animation tables. 'a' is max darkness, 'z' is maxbright.
    [SerializeField]private string animPatter = "mmamammmmammamamaaamammma";

    public bool Active
    {
        get => active;
        set
        {
            active = value;
            if (_light)
                _light.enabled = active;
        }
    }

    private Light2D _light;
    private void Start()
    {
        _light = GetComponent<Light2D>();
        if (Random.Range(0f, 1f) <= chanceUnstableLight)
            StartCoroutine(Animation());
        _generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();
        Active = active;
    }

    private void Update()
    {
        _light.intensity = _generator.MathIntensity(maxIntensity) + _deltaIntensity;
    }
    
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        var i = 0;
        while (true)
        {
            if (i + 1 == animPatter.Length)
            {
                _deltaIntensity = 0f;
                yield return new WaitForSeconds(Random.Range(1f, 8f));
            }
            i = (i + 1) % animPatter.Length;
            _deltaIntensity = maxIntensity / 100 * (animPatter[i] - 100);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
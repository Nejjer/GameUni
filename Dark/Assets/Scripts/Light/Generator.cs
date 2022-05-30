using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private float spendingFuelPerSecond = 0.01f;
    [SerializeField] private Image healthBar;
    [SerializeField] [Range(0, 5)] private float maxLightIntensity;
    private Animator _animator;
    private Light2D _light2D;
    private float _fuel = 1f;
    private float _maxFuel = 1f;

    private float Fuel
    {
        get => _fuel;
        set
        {
            if (value < 0)
                _fuel = 0;
            _fuel = value >= _maxFuel ? _maxFuel : value;
        }
    }

    private void Start()
    {
        _light2D = GetComponent<Light2D>();
        _animator = GetComponent<Animator>();
    }

    private void AddFuel(float value)
    {
        Fuel += value;
        if (value > 0) _animator.SetTrigger("AddFuel");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            AddFuel(inventory.GetFuel(_maxFuel - _fuel));
            Debug.Log($"Add fuel:, fuel is: {_fuel}");
        }
    }

    private void Update()
    {
        Fuel -= spendingFuelPerSecond * Time.deltaTime;
        healthBar.fillAmount = _fuel;
        _light2D.intensity = MathIntensity(maxLightIntensity);
        if (Fuel <= 0) EventManager.SendRestartGame();
    }

    public float MathIntensity(float maxIntensity)
    {
        var b = -Math.Sqrt(maxIntensity);
        var a = -b;
        return (float) (-Math.Pow(a * Fuel + b, 2) + maxIntensity);
        //See graph https://www.desmos.com/calculator/netyfxihwk?lang=ru
    }
}
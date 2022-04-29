using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private float spendingFuelPerSecond = 0.01f;
    [SerializeField] private Image healthBar;
    private float _fuel = 1f;
    private float _maxFuel = 1f;

    private float Fuel
    {
        get => _fuel;
        set
        {
            if (value < 0)
                return;
            _fuel = value >= _maxFuel ? _maxFuel : value;
            
        }
    }

    private void AddFuel(float value)
    {
        Fuel += value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            Fuel += inventory.GetFuel(_maxFuel - _fuel);
            Debug.Log($"Add fuel:, fuel is: {_fuel}");
        }
    }

    private void Update()
    {
        Fuel -= spendingFuelPerSecond * Time.deltaTime;
        healthBar.fillAmount = _fuel;   
    }
}

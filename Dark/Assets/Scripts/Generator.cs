using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private float spendingFuelPerSecond = 0.01f;
    [SerializeField] private Image healthBar;
    private float _fuel = 1f;
    private float _maxFuel = 1f;

    private void AddFuel(float value)
    {
        _fuel = _fuel + value >= _maxFuel ? _maxFuel : _fuel + value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            //TODO delete fuel from player inventory
            if (inventory.TryGetItem(out float fuel))
                AddFuel(fuel);
            Debug.Log($"Add fuel: {fuel}, fuel is: {_fuel}");
        }
    }

    private void FixedUpdate()
    {
        _fuel -= spendingFuelPerSecond * Time.fixedDeltaTime;
        healthBar.fillAmount = _fuel;   
    }
}

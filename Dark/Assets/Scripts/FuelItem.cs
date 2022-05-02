using UnityEngine;
using Random = UnityEngine.Random;

public class FuelItem : MonoBehaviour
{
    private float _fuel = 0f;
    [SerializeField] private float maxFuelCount;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            inventory.AddFuel(_fuel);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _fuel = Random.Range(0, maxFuelCount);
    }
}

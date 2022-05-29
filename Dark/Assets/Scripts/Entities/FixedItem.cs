using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FixedItem : MonoBehaviour
{
    [SerializeField] private int maxCount = 5;
    private int _count;

    private void Start()
    {
        _count = Random.Range(1, maxCount);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            inventory.AddFixedItem(_count);
            Destroy(gameObject);
        }
    }
}

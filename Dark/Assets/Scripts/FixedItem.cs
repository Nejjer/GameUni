using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            inventory.AddFixedItem();
            Destroy(gameObject);
        }
    }
}

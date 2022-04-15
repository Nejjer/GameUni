using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private readonly List<float> _items = new List<float>{0.1f, 0.08f};

    public bool TryGetItem(out float item)
    {
        if (_items.Count != 0)
        {
            item = _items.Last();
            _items.RemoveAt(_items.Count -1);
            return true;
        }

        item = 0;
        return false;
    }
}

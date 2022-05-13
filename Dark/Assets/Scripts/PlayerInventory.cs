using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private float _fuel = 0f;

    private float Fuel
    {
        get => _fuel;
        set
        {
            _fuel = (value >= maxFuelInInventory ? maxFuelInInventory : value);
            fuelCountUI.text = ((int) (_fuel * 100)).ToString();
        }
    }
    private int _fixedItem;
    private int FixedItem
    {
        get => _fixedItem;
        set
        {
            _fixedItem = value;
            fixedCountUI.text = _fixedItem.ToString();
        }
    }

    //private readonly List<FixedItem> _upgrades = new List<FixedItem>();
    [SerializeField] private Text fixedCountUI;
    [SerializeField] private Text fuelCountUI;
    [SerializeField] private float maxFuelInInventory = 1;

    public float GetFuel(float requireFuel)
    {
        if (requireFuel >= Fuel)
        {
            var res = Fuel;
            Fuel = 0;
            return res;
        }

        Fuel -= requireFuel;
        return requireFuel;
    }

    public void AddFuel(float fuel)
    {
        Fuel += fuel;
    }

    public void AddFixedItem()
    {
        FixedItem++;
    }

    public int GetFixedItem(int requireItems)
    {
        if (requireItems >= FixedItem)
        {
            var res = FixedItem;
            FixedItem = 0;
            return res;
        }
        FixedItem -= requireItems;
        return requireItems;
    }

    private void Start()
    {
        FixedItem = _fixedItem;
        Fuel = _fuel;
    }
}


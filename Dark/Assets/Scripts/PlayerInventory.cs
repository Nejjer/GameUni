using System;
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

    private readonly List<UpgradeItem> _upgrades = new List<UpgradeItem>();
    [SerializeField] private Text fuelCountUI;
    [SerializeField] private float maxFuelInInventory = 1;

    public float GetFuel(float neededFuel)
    {
        if (neededFuel >= Fuel)
        {
            var res = Fuel;
            Fuel = 0;
            return res;
        }

        Fuel -= neededFuel;
        return neededFuel;
    }

    public void AddFuel(float fuel)
    {
        Fuel += fuel;
    }

    private void Start()
    {
        Fuel = _fuel;
    }
}

internal class UpgradeItem
{
    
}

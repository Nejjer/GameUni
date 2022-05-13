using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPole : MonoBehaviour
{
    [SerializeField] private bool active;
    private bool Active
    {
        set
        {
            active = value;
            _light.enabled = active;
            _boxCollider2D.enabled = !active;
        }
    }

    [SerializeField] private int countForActivated;
    private Light2D _light;
    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _light = GetComponent<Light2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        Active = active;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
        {
            countForActivated -= inventory.GetFixedItem(countForActivated);
            Active = countForActivated <= 0;
        }
    }

    private void Update()
    {

        Active = active;
    }
}
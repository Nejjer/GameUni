using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FixedBUDKA : MonoBehaviour
{
    private LightGroup _lightGroup;

    private void Start()
    {
        //TODO Так или лучше [SerializeField] и в UI Unity кидать?
        _lightGroup = transform.GetComponentInParent<LightGroup>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
            _lightGroup.OnEnter(inventory);
    }
}

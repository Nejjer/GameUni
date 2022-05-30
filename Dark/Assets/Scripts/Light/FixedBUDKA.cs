using UnityEngine;

public class FixedBUDKA : MonoBehaviour
{
    private LightGroup _lightGroup;

    private void Start()
    {
        _lightGroup = transform.GetComponentInParent<LightGroup>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerInventory inventory))
            _lightGroup.OnEnter(inventory);
    }
}
using UnityEngine;

public class LightGroup : MonoBehaviour
{
    [SerializeField] private int countForActivated;
    [SerializeField] private bool active;

    private bool Active
    {
        set
        {
            active = value;
            foreach (var pole in _lightPoles)
                pole.Active = active;
            _collider.enabled = !active;
        }
    }

    private LightPole[] _lightPoles;
    private PolygonCollider2D _collider;

    void Start()
    {
        _lightPoles = transform.GetComponentsInChildren<LightPole>();
        _collider = GetComponent<PolygonCollider2D>();
        Active = active;
    }


    public void OnEnter(PlayerInventory inventory)
    {
        if (active != true)
        {
            countForActivated -= inventory.GetFixedItem(countForActivated);
            active = countForActivated <= 0;
            if (active)
                Active = active;
        }
    }
}
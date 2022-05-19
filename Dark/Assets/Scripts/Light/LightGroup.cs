using UnityEngine;

public class LightGroup : MonoBehaviour
{
    [SerializeField] private int requiredСountForActivated;
    [SerializeField] private bool active;
    private fixedBUDKAUI _budkaUI;
    private int _currentCount = 0;

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
        _budkaUI = transform.GetComponentInChildren<fixedBUDKAUI>();
        _budkaUI.SetProgress(active ? requiredСountForActivated : 0, requiredСountForActivated);
        Active = active;
    }


    public void OnEnter(PlayerInventory inventory)
    {
        if (active != true)
        {
            _currentCount += inventory.GetFixedItem(requiredСountForActivated - _currentCount);
            active = _currentCount >= requiredСountForActivated;
            _budkaUI.SetProgress(_currentCount, requiredСountForActivated);
            if (active)
                Active = active;
        }
    }
}
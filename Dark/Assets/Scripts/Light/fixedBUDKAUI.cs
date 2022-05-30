using UnityEngine;
using UnityEngine.UI;

public class fixedBUDKAUI : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject textContainer;
    [SerializeField] private Vector3 offset;
    private Camera _camera;

    private void Start() => _camera = Camera.main;

    private void Update()
    {
        textContainer.transform.position = _camera.WorldToScreenPoint(transform.position + offset);
    }

    public void SetProgress(int currentItems, int requiredItems)
    {
        if (currentItems == requiredItems)
            textContainer.SetActive(false);
        text.text = $"{currentItems}/{requiredItems}";
    }
}
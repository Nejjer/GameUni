using UnityEngine;
using UnityEngine.UI;

public class fixedBUDKAUI : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject textContainer;

    private void Update()
    {
        textContainer.transform.position = transform.position;
    }

    public void SetProgress(int currentItems, int requiredItems)
    {
        if (currentItems == requiredItems)
        {
            textContainer.SetActive(false);
            GetComponent<AudioSource>().Play();
        }
        text.text = $"{currentItems}/{requiredItems}";
    }
}
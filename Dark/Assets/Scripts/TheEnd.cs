using UnityEngine;

public class TheEnd : MonoBehaviour
{
    [SerializeField]private GameObject theEndText;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            theEndText.SetActive(true);
        }
    }
}

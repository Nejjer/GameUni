using UnityEngine;

public class TheEndCollider : MonoBehaviour
{
    [SerializeField]private GameObject theEndText;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            EventManager.SendEndGame();
        }
    }
}

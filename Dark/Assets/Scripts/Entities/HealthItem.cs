using Player;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private int health;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.AddHeath(health);
            Destroy(gameObject);
        }
    }
}

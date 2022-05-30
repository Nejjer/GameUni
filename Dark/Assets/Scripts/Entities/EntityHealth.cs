using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected int currentHealth = 100;

    public void GetDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            OnGetDamage();
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
                OnDeath();
        }
    }

    protected abstract void OnDeath();
    protected abstract void OnGetDamage();
}
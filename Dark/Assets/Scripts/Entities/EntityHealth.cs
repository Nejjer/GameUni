using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    [SerializeField] protected int health = 100;

    public void GetDamage(int damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log(health);
            if (health <= 0)
                OnDeath();
        }
        
    }

    protected abstract void OnDeath();
}
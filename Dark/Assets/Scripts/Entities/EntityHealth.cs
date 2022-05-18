using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityHealth : MonoBehaviour
{
    [SerializeField] protected int health = 100;

    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            OnDeath();
        }
    }

    public abstract void OnDeath();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private GameObject loot;
    [SerializeField] private GameObject fuel;
    [SerializeField] protected int health = 100;

    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Instantiate(Random.Range(0, 1) > 0.5 ? loot : fuel, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}